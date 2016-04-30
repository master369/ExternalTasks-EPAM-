(function () {
    "use strict";

    var text = '...У, по????????па была собака...',
        resultList = [],
        wordList = [''],
        punctuationList = [''],
        wordIndex = 0,
        punctIndex = 0,
        word,
        wordListLength,
        punctuationListLength,
        wordLength,
        textLength = text.length,
        symbolsMap = {},
        badSymbols = [],
        badSymbolsLength,
        ch,
        j,
        i;

    for (i = 0; i < textLength; i++) {
        ch = text[i];

        if (isLetter(text[i - 1]) && !isLetter(text[i])) {
            wordIndex++;
            wordList.push('');
            punctuationList[punctIndex] += ch;
        } else if (!isLetter(text[i - 1]) && isLetter(text[i])) {
            punctIndex++;
            punctuationList.push('');
            wordList[wordIndex] += ch;
        } else if (isLetter(ch)) {
            wordList[wordIndex] += ch;
        } else {
            punctuationList[punctIndex] += ch;
        }
    }

    wordList = removeFromArray(wordList, '');

    wordListLength = wordList.length;
    punctuationListLength = punctuationList.length;

    for (i = 0; i < wordListLength; i++) {
        word = wordList[i];
        wordLength = word.length;
        symbolsMap = {};
        for (j = 0; j < wordLength; j++) {
            ch = word[j];
            if (symbolsMap[ch] === undefined) {
                symbolsMap[ch] = 0;
            }
            if (symbolsMap[ch] > 0 && badSymbols.indexOf(ch) === -1) {
                badSymbols.push(ch);
            }
            symbolsMap[ch]++;
        }
      
    }

    badSymbolsLength = badSymbols.length;

    for (i = 0; i < wordListLength; i++) {
        for (j = 0; j < badSymbolsLength; j++) {
            wordList[i] = replaceAll(wordList[i], badSymbols[j], '');
        }
    }

    wordIndex = punctIndex = 0;

    if (isLetter(text[0])) {
        resultList.push(wordList[0]);
        wordIndex++;
    }

    while (wordIndex < wordListLength) {
        resultList.push(punctuationList[punctIndex++]);
        resultList.push(wordList[wordIndex++]);
    }

    if (punctIndex < punctuationListLength) {
        resultList.push(punctuationList[punctIndex++]);
    }

    console.log(resultList.join(''));

    function isLetter(ch) {
        return ' ?!:;,.\t'.indexOf(ch) === -1;
    }

    function replaceAll(str, search, replace) {
        return str.split(search).join(replace);
    }

    function removeFromArray(arr, removeItem) {
        var resultArr = [],
            arrLength = arr.length,
            item,
            i;

        for (i = 0; i < arrLength; i++) {
            item = arr[i];
            if (item !== removeItem) {
                resultArr.push(item);
            }
        }

        return resultArr;
    }
})();




