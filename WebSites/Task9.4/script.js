(function (window) {
    'use strict';
    var routes = {},
        el = null,
        document = window.document,
        body = document.body,
        pageHashList = ['/', '/page1', '/page2'],
        pageNumber = 0,
        timePageChange = 5000,
        isPlayState = true,
        intervalId;

    route('/', 'home');
    route('/page1', 'template1');
    route('/page2', 'template2');

    window.addEventListener('hashchange', router);
    window.addEventListener('load', router);

    document.addEventListener('DOMContentLoaded', function () {
        body.addEventListener('click', function (event) {
            var target = event.target;

            if (target.className.indexOf('toggle-play') === -1) {
                return;
            }

            target.innerText = isPlayState ? 'Play' : 'Pause';

            if (isPlayState) {
                clearInterval(intervalId);
            } else {
                initInterval();
            }

            isPlayState = !isPlayState;            
        });
    });

    initInterval();

    function initInterval() {
        intervalId = setInterval(function () {
            changeLocationHash(pageHashList[pageNumber]);
            pageNumber++;
            pageNumber %= pageHashList.length;
        }, timePageChange);
        //interval should update every 1 second 
    }

    function route(path, templateId) {
        routes[path] = { templateId: templateId };
        pageNumber = pageHashList.indexOf(path);
    }

    function changeLocationHash(hash) {
        window.location.hash = '#' + hash;
    }

    function router() {
        var url = location.hash.slice(1) || '/',
            route = routes[url];

        el = el || document.getElementById('view');

        if (el) {
            el.innerHTML = document.getElementById(route.templateId).innerHTML;
        }
    }
})(window);