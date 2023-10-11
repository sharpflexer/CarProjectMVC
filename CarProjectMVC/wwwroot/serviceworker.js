const channelTokenBroadcast = new BroadcastChannel('channelToken');
const channelRefreshBroadcast = new BroadcastChannel('channelRefresh');

var accessToken;
channelTokenBroadcast.onmessage = function (event) {
    console.log("channel token works");
    accessToken = event.data.accessToken;
}

var refreshToken;
channelRefreshBroadcast.onmessage = (event) => {
    refreshToken = event.data.refreshToken;
}

self.addEventListener("fetch", event => {
    console.log(event.request.url);
    console.log(event.request.url.match('^.*(\/Read\/).*$'));
    if (event.request.url.match('^.*(\/Read\/).*$')) {
        console.log('WORKER: Fetching', event.request);
        /*    var token = localStorage.getItem('AccessToken');*/
        event.respondWith(customHeaderRequestFetch(event, accessToken, refreshToken));
    }
});

function customHeaderRequestFetch(event, token, refresh) {
    const headers = new Headers(event.request.headers);

    headers.set('Authorization', token);
    headers.set('Refresh', refresh);

    const newRequest = new Request(event.request, {
        mode: 'same-origin',
        credentials: 'omit',
        headers: headers
    })
    return fetch(newRequest)
}