# meme generator

1. Select images to use.
2. Select sentence to use.
3. Adjusting font size & style.
4. There you go, you just created a meme.

## Advance feature

### Using lua console
``` wrap
Press Ctrl+~ to open lua console.
```
You can write any lua program there freely, but here we mostly use it to add items to program.

### Add new sentence via lua console
``` lua=
addSentence("some interesting words")
```
example:
```lua=
addSentence("When it's spooky time of the yeay.")
```

### Add new image via lua console

``` lua=
addImg([[pathToImg]], "imgName")
```
example:
``` lua=
addImg([[C:\Users\weber\Pictures\16_programmer.jpg]], "life of a programmer")
```
Notice that pathToImg is enclosed by two pairs of square brackets.
This is to prevent escape character to happen.

* There will be a new RadioButton shows up right after you added them.

### Save meme
Press 'export meme' button, chose a location and image format to save your meme.