public string WordReverse(string sentence)
{
    return string.Join(" ", sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Reverse());
}