(function () {
    "use strict";

    var text = 'У попа была собака',
        wordList = [''],
        punctuationMarkList = [''],
        wordIndex = 0,
        punctIndex = 0,
        textLength = text.length,
        ch,
        i;

    for (i = 0; i < textLength; i++) {
        ch = text[i];

        if (isLetter(ch)) {
            wordList[wordIndex] += ch;
        } else {
            if (isLetter(text[i - 1]) && !isLetter(text[i]))

                wordIndex++;
            wordList.push('');
        }
    }

    function isLetter(ch) {
        return ' ?!:;,.\t'.indexOf(ch) === -1;
    }
})();







//REMOVE THIS SHIT!!!!!111111
////function unique(arr) {
////    var result = [];

////    nextInput:



////        for (var i = 0; i < arr.length; i++) {
////            alert(arr.split(''));
////            var str = arr[i]; 
////            for (var j = 0; j < str.length; j++) { // ищем, был ли он уже?
////                if (str[j] == str[j+1]) continue nextInput; // если да, то следующий
////            }
////            result.push(str);
////        }

////    return result;
////}
////var string = 'У попа была собака';
////var arr = string.split('');
////alert(unique(arr));

//////var strings = ["кришна", "кришна", "харе", "харе",
//////  "харе", "харе", "кришна", "кришна", "8-()"
//////];

//////alert(unique(str)); // кришна, харе, 8-()

//function find_unique_characters( string ){
//    var unique='';
//    for(var i=0; i<string.length; i++){
//        if(string.lastIndexOf(string[i]) == string.indexOf(string[i])){
//            unique += string[i];
//        }
//    }
//    return unique;
//}

////alert(find_unique_characters('baraban'));​

////$(function () {
////    $('#button1').click(function () {
////        $('#txtbx2').val(RemoveDuplicateChars($('#txtbx1').val()));
////    });
////});

///* This assumes you have trim the string and checked if it empty */
////function RemoveDuplicateChars(str) {
////    var curr_index = 0;
////    var curr_char;
////    var strSplit;
////    var found_first;
////    while (curr_char != '') {
////        curr_char = str.charAt(curr_index);
////        /* Ignore spaces */
////        if (curr_char == ' ') {
////            curr_index++;
////            continue;
////        }
////        strSplit = str.split('');
////        found_first = false;
////        for (var i = 0; i < strSplit.length; i++) {
////            if (str.charAt(i) == curr_char && !found_first)
////                found_first = true;
////            else if (str.charAt(i) == curr_char && found_first) {
////                /* Remove it from the string */
////                str = setCharAt(str, i, '');
////            }
////        }
////        curr_index++;
////    }
////    return str;
////}
////function setCharAt(str, index, chr) {
////    if (index > str.length - 1) return str;
////    return str.substr(0, index) + chr + str.substr(index + 1);
////}

//var str = 'У попа была собака';
//strSplit = str.split(' ');
//for (var i = 0; i < strSplit.length; i++) {
//console.log(find_unique_characters(strSplit[i]));
//}
