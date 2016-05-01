(function (window) {
    "use strict";

    document.addEventListener('DOMContentLoaded', function () {
        var mathExpressionField = document.getElementsByClassName("math-expression")[0],
            answerField = document.getElementsByClassName("answer")[0];

        window.calculate = function () {
            var mathExpression = mathExpressionField.value;

            answerField.value = calc(mathExpression);

            return false;
        };
    });

    function calc(expr) {
        var arr = expr.match(/[1-9][0-9]*\.[0-9]+|[1-9][0-9]*|0.[0-9]+|[//*+-]/g),
            result = 0,
            op = '+',
            arrLength = arr.length,
            item,
            i;

        for (i = 0; i < arrLength; i++) {
            item = arr[i];

            switch (item) {
                case "+":
                case "-":
                case "*":
                case "/":
                    op = item;
                    break;
                default:
                    item = parseFloat(item);
                    switch (op) {
                        case "+": result += item; break;
                        case "-": result -= item; break;
                        case "*": result *= item; break;
                        case "/": result /= item; break;
                        default: break;
                    }

            }
        }

        return result.toFixed(2);
    }
})(window);

