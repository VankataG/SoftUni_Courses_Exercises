function extract(content) {
    let text = document.getElementById('content').textContent;

    let matches = text.matchAll(/\(([^)]+)\)/g)

    let results = [];
    for (let match of matches) {
        match = match.splice(1, match.length - 1);
        results.push(match);
    }
    
    return results.join('; ');
}