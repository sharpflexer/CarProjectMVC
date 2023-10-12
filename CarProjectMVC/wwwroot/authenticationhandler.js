const channelTokenBroadcast = new BroadcastChannel('channelToken');
const channelRefreshBroadcast = new BroadcastChannel('channelRefresh');

var accessToken;
channelTokenBroadcast.onmessage = function (event) {
    accessToken = event.data.accessToken;
}

var refreshToken;
channelRefreshBroadcast.onmessage = (event) => {
    refreshToken = event.data.refreshToken;
}

self.addEventListener("fetch", event => {
    if (event.request.url.match('^.*(\/Read).*$') ||
        event.request.url.match('^.*(\/Create).*$') ||
        event.request.url.match('^.*(\/Update).*$') ||
        event.request.url.match('^.*(\/Delete).*$') ||
        event.request.url.match('^.*(\/ReadJS).*$')) {

        event.respondWith((async () => {
            const response =
                await customHeaderRequestFetch(event, accessToken, refreshToken);
            if (response.status == 401) {
                if (response.headers.get("IS-TOKEN-EXPIRED") == "true") {
                    console.log("401 trying to refresh");
                    var jwtResponse = await fetch("/Auth/Refresh", {
                        headers: {
                            Authentication: accessToken,
                            Refresh: refreshToken
                        }
                    });
                    console.log(jwtResponse);
                    var jwtToken = await jwtResponse.json();
                    console.log(jwtToken);

                    accessToken = jwtToken.accessToken;
                    refreshToken = jwtToken.refreshToken;
                    return await customHeaderRequestFetch(event, accessToken, refreshToken);
                }
                else {
                    console.log("401 redirect to login");
                    return await fetch("/Login/Index");
                }
            }
            return response;
        })());
        //event.respondWith(
        //    customHeaderRequestFetch(event, accessToken, refreshToken)
        //);
        console.log("reponse with succeed");
    }

});

self.serviceWorker.onerror = function(event) {
    console.log(event);
    console.log("THE ON ERROR BEGINS");
};

function customHeaderRequestFetch(event, token, refresh) {
    const headers = new Headers(event.request.headers);

    headers.set('Authorization', token);
    headers.set('Refresh', refresh);

    const newRequest = new Request(event.request, {
        mode: 'same-origin',
        credentials: 'omit',
        headers: headers
    })
    return fetch(newRequest);
}