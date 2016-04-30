MyApp.Functional = MyApp.Functional || (function (utils) {
    "use strict";

    var appendElements = utils.appendElements,
        removeElements = utils.removeElements,
        findClass = utils.findClass;

    return {
        move: move,
        moveAll: moveAll
    };
    
    function move(element, fromClass, toClass) {
        var mainContainer = element.closest('.main'),
            selectFrom = findClass(mainContainer, fromClass),
            selectTo = findClass(mainContainer, toClass),
            selectedOptions = selectFrom.selectedOptions;

        appendElements(selectTo, selectedOptions);        
        removeElements(selectedOptions);
    }

    
    function moveAll(element, fromClass, toClass) {
        var mainContainer = element.closest('.main'),
            selectFrom = findClass(mainContainer, fromClass),
            selectTo = findClass(mainContainer, toClass),
            allOptions = selectFrom.options;

        appendElements(selectTo, allOptions);
        removeElements(allOptions);
    }
})(MyApp.Utils);