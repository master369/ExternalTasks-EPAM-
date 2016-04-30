MyApp.Utils = MyApp.Utils || (function () {
    "use strict";

    return {
        appendElements: appendElements,
        removeElements: removeElements,
        findClass: findClass,
    };

    function appendElements(container, elements) {
        var docFrag = document.createDocumentFragment(),
            elementsLength = elements.length,
            i;

        for (i = 0; i < elementsLength; i++) {
            docFrag.appendChild(elements[i].cloneNode(true));
        }

        container.appendChild(docFrag);
    }

    function removeElements(elements) {
        while (elements.length > 0) {
            elements[0].remove();
        }
    }

    function findClass(element, className) {
        var foundElement = null,
            found;

        function recurse(element, className, found) {
            var i, j,
                childElement,
                childNodes = element.childNodes,
                childsLength = childNodes.length,
                classes,
                classesLength;


            for (i = 0; i < childsLength && !found; i++) {
                childElement = childNodes[i];
                classes = childElement.className != undefined ? childElement.className.split(" ") : [];
                classesLength = classes.length;

                for (j = 0; j < classesLength; j++) {
                    if (classes[j] === className) {
                        found = true;
                        foundElement = childElement;
                        break;
                    }
                }

                if (found) break;

                recurse(childElement, className, found);
            }
        }

        recurse(element, className, false);

        return foundElement;
    }
})();