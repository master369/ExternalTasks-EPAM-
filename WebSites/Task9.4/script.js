(function (window) {
    'use strict';
    var routes = {},
        el = null,
        document = window.document,
        body = document.body,
        pageHashList = ['/', '/page1', '/page2'],
        pageNumber = 0,
        countdownMax = 5,
        countdown = countdownMax,
        timeTick = 1000,
        timerContainer,
        isPlayState = true,
        intervalId;

    route('/', 'home');
    route('/page1', 'template1');
    route('/page2', 'template2');

    window.addEventListener('hashchange', router);
    window.addEventListener('load', router);

    document.addEventListener('DOMContentLoaded', function () {
        timerContainer = document.getElementById('timer');
        setInnerText(timerContainer, countdownMax);

        body.addEventListener('click', function (event) {
            var target = event.target;

            if (target.className.indexOf('toggle-play') === -1) {
                return;
            }
            setInnerText(target, isPlayState ? 'Play' : 'Pause');

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
        var pageListLength = pageHashList.length;

        intervalId = setInterval(function () {
            countdown--;
            setInnerText(timerContainer, countdown);

            if (countdown < 1) {
                pageNumber++;

                if (pageNumber === pageListLength) {
                    var message = "Нажмите [ОК] чтобы вернуться на 1 страницу или [Cancel] чтобы закрыть окно браузера.",
                        closeFlag = !confirm(message);

                    if (closeFlag) {
                        window.open('', '_self').close();
                    }
                }

                pageNumber %= pageListLength;
                changeLocationHash(pageHashList[pageNumber]);
                countdown = countdownMax;
            }

        }, timeTick);
    }

    function route(path, templateId) {
        routes[path] = { templateId: templateId };
    }

    function changeLocationHash(hash) {
        window.location.hash = '#' + hash;
    }

    function router() {
        var url = location.hash.slice(1) || '/',
            pageNumber = pageHashList.indexOf(url),
            route = routes[url];

        el = el || document.getElementById('view');

        if (el) {
            el.innerHTML = document.getElementById(route.templateId).innerHTML;
        }

        countdown = countdownMax;
    }

    //function closeWP() {
    //    var Browser = navigator.appName;
    //    var indexB = Browser.indexOf('Explorer');

    //    if (indexB > 0) {
    //        var indexV = navigator.userAgent.indexOf('MSIE') + 5;
    //        var Version = navigator.userAgent.substring(indexV, indexV + 1);

    //        if (Version >= 7) {
    //            window.open('', '_self', '');
    //            window.close();
    //        }
    //        else if (Version == 6) {
    //            window.opener = null;
    //            window.close();
    //        }
    //        else {
    //            window.opener = '';
    //            window.close();
    //        }

    //    }
    //    else {
    //        window.close();
    //    }
    //}

    function setInnerText(container, text) {
        container.textContent = container.innerText = text;
    }
})(window);