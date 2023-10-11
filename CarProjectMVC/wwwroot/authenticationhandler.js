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
        console.log('WORKER: Fetching', event.request);
        event.respondWith(
            customHeaderRequestFetch(event, accessToken, refreshToken)
                .catch(function (r) {
                    response = r;
                    console.log(response);
                    if (response.status == 401)
                        window.location.href = "/Login/Index";
                })
        );           
    }
    console.log(self.serviceWorker);

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