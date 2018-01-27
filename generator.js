const dataFactory = require("./data");

function generate() {
    const data = dataFactory.getInstance();
    const bioLength = getRandomBioLength();
    let bio = "";
    let done = false;

    while (!done) {
        const newSegment = generateSegment();

        if (newSegment && newSegment.length > 0) {
            const potentialLength = bio.length + 1 + newSegment.length;

            if (potentialLength > bioLength) {
                done = true;
            }
            else {
                if (bio.length > 0) {
                    bio += " ";
                }
                bio += newSegment;
            }
        }
    }

    return bio;

    function generateSegment() {
        let text = "";
        const num = randomInt(100);

        if (num < 3) {
            return getRandomFullSentence();
        }

        if (num < 33) {
            const simpleNoun = getRandomSimpleNoun();

            if (simpleNoun && simpleNoun.length) {
                text = simpleNoun;

                if (randomInt(2) < 1) {
                    const adjective = getRandomSuperfluousAdjective();

                    if (adjective && adjective.length) {
                        text = adjective + " " + text;
                    }
                }

                text = sentenceize(text);
            }

            return text;
        }

        const subject = getRandomSubject();
        let subjectBoundNoun = getRandomSubjectBoundNoun();
        if (subject && subject.length && subjectBoundNoun && subjectBoundNoun.length) {
            if (subjectBoundNoun === "%aholic" && subject.endsWith("a")) {
                subjectBoundNoun = "%holic";
            }

            text = subjectBoundNoun.replace("%", subject);

            if (randomInt(2) < 1) {
                const superfluousAdjective = getRandomSuperfluousAdjective();
                if (superfluousAdjective) {
                    text = superfluousAdjective + " " + text;
                }
            }

            text = sentenceize(text);
        }
        
        return text;
    }
    
    function getRandomBioLength() {
        const num = randomInt(100);
        
        if (num < 5)
            return 160;

        if (num < 20)
            return 140;

        if (num < 50)
            return 120;

        return 100;
    }
    
    function getRandomSimpleNoun() {
        const index = randomInt(data.simpleNouns.length);
        const result = data.simpleNouns[index];
        data.simpleNouns = data.simpleNouns.filter(x => x !== result);
        return result;
    }
    
    function getRandomSubjectBoundNoun() {
        const index = randomInt(data.subjectBoundNouns.length);
        const result = data.subjectBoundNouns[index];
        data.subjectBoundNouns = data.subjectBoundNouns.filter(x => x !== result);
        return result;        
    }
    
    function getRandomSubject() {
        const index = randomInt(data.subjects.length);
        const result = data.subjects[index];
        data.subjects = data.subjects.filter(x => x !== result);
        return result;
    }
    
    function getRandomSuperfluousAdjective() {
        const index = randomInt(data.superfluousAdjectives.length);
        const result = data.superfluousAdjectives[index];
        data.superfluousAdjectives = data.superfluousAdjectives.filter(x => x !== result);
        return result;
    }
    
    function getRandomFullSentence() {
        const index = randomInt(data.fullSentences.length);
        const result = data.fullSentences[index];
        data.fullSentences = data.fullSentences.filter(x => x !== result);
        return result;        
    }
}

function sentenceize(target) {
    if (!target || target.length === 0)
        return "";

    const upperFirstChar = target.charAt(0).toUpperCase();
    const tail = target.slice(1);
    const periodIfNeeded = !target.endsWith(".") ? "." : "";

    return upperFirstChar + tail + periodIfNeeded;
}

function needsPeriod(target) {
    return target[target.length - 1] !== ".";
}

function randomInt(max) {
    const min = 0;
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

module.exports = generate;
