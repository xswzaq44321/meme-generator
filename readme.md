# meme generator

1. Select images to use.
2. Select sentence to use.
3. Adjusting font size & style.
4. There you go, you created a meme.

## Advance feature

### Using lua console
``` wrap
Press Ctrl+~ to open lua console.
```

### Add new sentence via lua console
``` lua=
addSentence("some interesting words")
```

### Add new image via lua console

``` lua=
addImg([[pathToImg]], "imgName")
```
Notice that pathToImg is enclosed by two pairs of square brackets.
This is to prevent escape character to happen.

There will be a new RadioButton shows up right after you added them.