using System;
using System.Collections.Generic;
using System.Linq;


public class Scripture
{
private Reference _reference;
private List<Word> _words;


public Scripture(Reference reference, string text)
{
_reference = reference;
_words = text.Split(" ").Select(w => new Word(w)).ToList();
}


public void HideRandomWords(int count)
{
Random rand = new Random();
List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();


for (int i = 0; i < count && visibleWords.Count > 0; i++)
{
Word word = visibleWords[rand.Next(visibleWords.Count)];
word.Hide();
visibleWords.Remove(word);
}
}


public void RevealOneWord()
{
Word hidden = _words.FirstOrDefault(w => w.IsHidden());
if (hidden != null)
{
hidden.Reveal();
}
}


public bool AllWordsHidden()
{
return _words.All(w => w.IsHidden());
}


public string GetDisplayText()
{
string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
return $"{_reference.GetDisplayText()}\n{text}";
}
}