const express = require("express");
const server = express();
const generateBio = require("./generator");
const port = 8070;

server.get("/generate", function (req, res) {
    const bio = generateBio();
    res.send(bio);
});

server.use('/', express.static(__dirname + "/", {extensions: ["html", "css"]}));

server.listen(port);

console.log("listening on port", port);
