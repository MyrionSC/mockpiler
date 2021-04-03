
# Mockpiler

Convert json to C# mock. Formatting not included. Your IDE can do that.


## TODO

- docker


## example curl

```
curl -X POST "https://marand.dk/mockpiler/" -H "accept: text/plain" -d "{ \"glossary\": { \"title\": \"example glossary\", \"GlossDiv\": { \"title\": \"S\", \"GlossList\": { \"GlossEntry\": { \"ID\": \"SGML\", \"SortAs\": \"SGML\", \"GlossTerm\": \"Standard Generalized Markup Language\", \"Acronym\": \"SGML\", \"Abbrev\": \"ISO 8879:1986\", \"GlossDef\": { \"para\": \"A meta-markup language, used to create markup languages such as DocBook.\", \"GlossSeeAlso\": [\"GML\", \"XML\"] }, \"GlossSee\": \"markup\" } } } }}"
```

becomes...

```
new()
{
glossary = new()
{
title = "example glossary",
GlossDiv = new()
{
title = "S",
GlossList = new()
{
GlossEntry = new()
{
ID = "SGML",
SortAs = "SGML",
GlossTerm = "Standard Generalized Markup Language",
Acronym = "SGML",
Abbrev = "ISO 8879:1986",
GlossDef = new()
{
para = "A meta-markup language, used to create markup languages such as DocBook.",
GlossSeeAlso = new() {
"GML",
"XML"
}
},
GlossSee = "markup"
}
}
}
}
}
```

