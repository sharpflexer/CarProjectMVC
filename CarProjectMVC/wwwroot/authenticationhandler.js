const channelTokenBroadcast = new BroadcastChannel('channelToken');

var accessToken;
channelTokenBroadcast.onmessage = function (event) {
    accessToken = event.data.accessToken;
}

self.addEventListener("fetch", event => {
    if (event.request.url.match('^.*(\/Read).*$') ||
        event.request.url.match('^.*(\/Create).*$') ||
        event.request.url.match('^.*(\/Update).*$') ||
        event.request.url.match('^.*(\/Delete).*$') ||
        event.request.url.match('^.*(\/ReadJS).*$') ||
        event.request.url.match('^.*(\/Users).*$')) {

        event.respondWith((async () => {
            const response =
                await customHeaderRequestFetch(event, accessToken);
            if (response.status == 401) {
                if (response.headers.get("IS-TOKEN-EXPIRED") == "true") {
                    console.log("401 trying to refresh");
                    var jwtResponse = await fetch("/Auth/Refresh", {
                        headers: {
                            Authentication: accessToken,
                        }
                    });
                    accessToken = await jwtResponse.text();

                    return await customHeaderRequestFetch(event, accessToken);
                }
                else {
                    console.log("401 redirect to login");
                    return await fetch("/Login/Index");
                }
            }
            return response;
        })());
        console.log("reponse with succeed");
    }

});

self.serviceWorker.onerror = function(event) {
    console.log(event);
    console.log("THE ON ERROR BEGINS");
};

function customHeaderRequestFetch(event, token) {
    const headers = new Headers(event.request.headers);

    headers.set('Authorization', token);

    const newRequest = new Request(event.request, {
        mode: 'same-origin',
        credentials: 'omit',
        headers: headers
    })
    return fetch(newRequest);
}