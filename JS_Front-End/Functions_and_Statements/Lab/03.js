function repeat(text, count)
{
    let originalText = text;
    for (let i = 1; i < count; i++)
    {
        text += originalText;
    }

    return text;
}