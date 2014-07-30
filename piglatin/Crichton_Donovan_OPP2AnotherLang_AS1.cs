using System;
using System.Drawing;
using System.Windows.Forms;

public class FormPigLatin : Form {
   //Declare form control variables
   private TextBox tbxEnglish;
   private TextBox tbxPigLatin;
   private Label lblEnglish;
   private Label lblPigLatin;
   private Button btnTranslate;
   private Button btnClear;
   private Button btnExit;

   //constructor
   public FormPigLatin() {
   	InitialiseComponents();
	}

   /*****************************************************************
	Method to initialise all the form controls and components
	
	@return void
	*****************************************************************/
   private void InitialiseComponents() {
   //size and position varibles to avoid magic numbers
   	int width = 400;
      int height = 400;
      int lblHeight = 24;
      int lblWidth = 300;
      int btnWidth = width / 4;
      int btnHeight = (int) (height * 0.08);
      int leftPos = (int) (width - (width * 0.95));
      int topPos = (int) (height - (height * 0.95));
      int bottomPos = 10;
      int fieldHeight = 100;
      int fieldWidth = width - (2 * leftPos);

      //instantiate component objects
      this.tbxEnglish = new System.Windows.Forms.TextBox();
      this.tbxPigLatin = new System.Windows.Forms.TextBox();
      this.lblEnglish = new System.Windows.Forms.Label();
      this.lblPigLatin = new System.Windows.Forms.Label();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnExit = new System.Windows.Forms.Button();
      this.btnTranslate = new System.Windows.Forms.Button();

      //------------------SET OBJECT PROPERTIES------------------------

      //English text label
      this.lblEnglish.Location = new Point(leftPos, topPos);
      this.lblEnglish.Size = new Size(lblWidth, lblHeight);
      this.lblEnglish.Font = new Font(FontFamily.GenericSansSerif, 12);
      this.lblEnglish.Text = "Enter English text here:";
      topPos += lblEnglish.Height;
       
      //English textBox  
      this.tbxEnglish.AcceptsReturn = true;
      this.tbxEnglish.AcceptsTab = true;
      this.tbxEnglish.Location = new Point(leftPos, topPos);
      this.tbxEnglish.Font = new Font(FontFamily.GenericSansSerif, 12);
      this.tbxEnglish.Size = new Size(fieldWidth, fieldHeight);
      this.tbxEnglish.Multiline = true;
      this.tbxEnglish.ScrollBars = 
         System.Windows.Forms.ScrollBars.Vertical;
      this.Name = "tbxEnglish";
      topPos += tbxEnglish.Height + 50;

      //Pig Latin label 
      this.lblPigLatin.Location = new Point(leftPos, topPos);
      this.lblPigLatin.Size = new Size(lblWidth, lblHeight);
      this.lblPigLatin.Font = new Font(FontFamily.GenericSansSerif, 12);
      this.lblPigLatin.Text = "Pig Latin Translation:";
      topPos += lblPigLatin.Height;

      //Pig Latin textBox
      this.tbxPigLatin.AcceptsReturn = true;
      this.tbxPigLatin.AcceptsTab = true;
      this.tbxPigLatin.Location = new Point(leftPos, topPos);
      this.tbxPigLatin.Font = new Font(FontFamily.GenericSansSerif, 12);
      this.tbxPigLatin.Size = new Size(fieldWidth, fieldHeight);
      this.tbxPigLatin.Multiline = true; 
      this.tbxPigLatin.ScrollBars = 
         System.Windows.Forms.ScrollBars.Vertical;
      this.Name = "tbxPigLatin";

      //Translate button
      this.btnTranslate.Location = new Point(leftPos, height 
         - btnHeight - bottomPos);
      this.btnTranslate.Size = new Size(btnWidth, btnHeight);
      this.btnTranslate.Font = new Font(FontFamily.GenericSansSerif, 12);
      this.btnTranslate.Text = "Translate";
      this.btnTranslate.Click += new System.EventHandler(
         this.btnTranslate_Click);

      //Clear button
      this.btnClear.Location = new Point(leftPos 
         + btnWidth + leftPos, height - btnHeight - bottomPos);
      this.btnClear.Size = new Size(btnWidth, btnHeight);
      this.btnClear.Font = new Font(FontFamily.GenericSansSerif, 12);
      this.btnClear.Text = "Clear";
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

      //Exit button
      this.btnExit.Location = new Point(leftPos + fieldWidth 
         - btnWidth, height - btnHeight - bottomPos);
      this.btnExit.Size = new Size(btnWidth, btnHeight);
      this.btnExit.Font = new Font(FontFamily.GenericSansSerif, 12);
      this.btnExit.Text = "Exit";
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

        //Pig Latin Form
      this.ClientSize = new System.Drawing.Size(400, 400);
      this.Controls.Add(this.lblEnglish);
      this.Controls.Add(this.tbxEnglish);
      this.Controls.Add(this.lblPigLatin);
      this.Controls.Add(this.tbxPigLatin);
      this.Controls.Add(this.btnTranslate);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.btnExit);
      this.Text = "Pig Latin Translator";
  		//-------------------END initComponents METHOD-----------------
	}
   
   [STAThread]
   static void Main() {
   	//set window style to current windows theme
      Application.EnableVisualStyles();
      Application.Run(new FormPigLatin());
   }

   /*****************************************************************
	Exit button event handler method - exits application.

	@param sender: the object sending the event, e: the event arguments
	@return void
	******************************************************************/
   private void btnExit_Click(object sender, System.EventArgs e) {
      Application.Exit();
   }

   /*****************************************************************
	Clear button event hander method - clears the two text boxes
	
	@param sender: the object sending the event, e: event arguments
	@return void
	*****************************************************************/
   private void btnClear_Click(object sender, System.EventArgs e) {
      tbxEnglish.Text = null;
      tbxPigLatin.Text = null;
   }

   /*****************************************************************
	Translate button event handler method

	<p>
	Checks to see if the english text box has no 'real' text, if not
	then calls the translate method and assignes the result to the 
	pig latin text box
	</p>

	@param sender: the object sending the event, e: event arguments
	@return void
	@see methods translate, convert
	*****************************************************************/
   private void btnTranslate_Click(object sender, System.EventArgs e) {
      if (tbxEnglish.Text.Equals('\t') || tbxEnglish.Text.Equals(' ') ||
         tbxEnglish.Text.Equals(null)) {
            return;
      }
      else {
         tbxPigLatin.Text = translate(tbxEnglish.Text);
      }
   }

   /*****************************************************************
	Translates a string from english to piglatin.

	<p>
	Splits the incoming string into an array, and looks over the array
	once (taking N time), calling the convert method for each entry
	before joining the string upon completion	
	</p>

	@param s: the incoming english string for translation
	@return string: the completed piglatin translation from english
	@see methods btnTranslate_Click, convert
	*****************************************************************/
   private string translate(string s) {
      string[] delimiter = new string[] {" "};
      string[] sArray = s.Split(
         delimiter, StringSplitOptions.RemoveEmptyEntries);
      for (int i = 0; i < sArray.Length; i++) {
         sArray[i] = convert(sArray[i]);
      }
      s = String.Join (" ", sArray);
      return s;
   }

   /*****************************************************************
	Executes the piglatin translation logic

	<p>
	performs a number of logical boolean tests to determine the specific
	translation operations to perform on the incoming english word in
	order to convert to piglatin.
	NOTE: used char and ASCII, along with string methods to demonstrate
			knowledge of both sets of operations.
	</p>

	@param s: the incoming english word
	@return string: the converted piglatin word
	@see methods translate, btnTranslate_Click
	******************************************************************/
   private string convert(string s) {
      //declare conversion variables
      int wordStart = 0;
      int wordEnd = 0;
      int vowelIndex = 0;
      char[] vowels = new char[] {'A', 'E', 'I', 'O', 'U', 'Y'};
      char[] c = new char[s.Length];
      //begin execution
		c = s.ToCharArray(); 
      wordStart = wordStartIndex(c);
      wordEnd = wordEndIndex(c);
      //Y is treated as a consonant if its the first letter
		if (c[wordStart] == 'y' || c[wordStart] =='Y') {
        vowelIndex = 1;
      } 
      else {
         vowelIndex = s.ToUpper().IndexOfAny(vowels);
      }
      if (leaveUnchanged(c, wordStart, wordEnd)) {
         return s;
      }
      else if (vowelIndex == -1) {
       return useAy(s, wordEnd);
      }
      else if (firstLetterVowel(c, wordStart, vowelIndex)) {
         return useWay(s, wordEnd);
      }
      else {
         s = swapLetters(s, wordStart, wordEnd, vowelIndex);
         return useAy(s, wordEnd);      
      }
   }
   
	/******************************************************************
	Checks if a character is a capital letter based on ASCII values
	
	@param c: the character checked
	@return bool: true if the character is a capital letter
	@see methods: swapCase, notLetter
	******************************************************************/   
   private bool isCapital(char c) {
      return (c > 64 && c < 91);
   }

   /******************************************************************
	Checks if a character is a lower case letter based on ASCII values

	@param c: the character checked
	@return bool: true if the character is lower case
	@see methods: swapCase, notLetter
	******************************************************************/
   private bool isLowerCase(char c) {
      return (c > 96 && c < 123);
   }

	/*****************************************************************
	Checks if the character is not a letter
	
	@param c: the character checked
	@return bool: returns true if the character is not a letter
	@see methods: isLowerCase, isCapital
	*******************************************************************/   
	private bool notLetter(char c) {
      return (!(isCapital(c) || isLowerCase(c)));
   }

   /******************************************************************
	Swaps the case of a letter via ASCII, doing nothing if not a letter

	@param c: The character to swap
	@return char: The upper case of c if c is lower, the lower case if
		c is upper, or c if neither.
	@see methods: isLowerCase, isCapital
	*******************************************************************/
   private char swapCase(char c) {
      if (isLowerCase(c)) {
         return (char) ((int) c - 32);
      } 
      else if (isCapital(c)) {
         return (char) ((int) c + 32);
      }
      else return c;
   }
   
   /******************************************************************
	Finds the array index of the first letter in a word

	@param c: the character array to search
	@return int: the index of the first letter
	@see method: convert
	*******************************************************************/
	private int wordStartIndex(char[] c) {
      for (int i = 0; i < c.Length - 1; i++) {
            if (!notLetter(c[i])) {
				return i;
			}   
		}
      return -1;
	}
   
	/******************************************************************
	Finds the array index of the last letter in a word

	@param c: the character array to search
	@return int: the index of the last letter
	@see method: convert
	******************************************************************/   
	private int wordEndIndex(char[] c) {
   	for (int i = c.Length - 1; i > 0; i--) {
      	if (!notLetter(c[i])) {
         	return i;
         }
      }
     	return -1;
	}
      
   /***************************************************************
	Checks if the word should be left as is
	
	<p>
	A word should be left as is if it contains more than one ' or
	if it contains any character that is not a letter
	NOTE: word in this instance excludes any pre and post punctuation
			so 'hello' would return false, but 'he'l'lo' would return true
	</p>
   
	@param c: the character array to search through
	@param start: the index of the first letter of the word
	@param end: the index of the last letter of the word
	@return bool: succeeds if word contains a special character or multiple
					  apostrophes
	@see methods: convert, notLetter, notAWord
	**********************************************************************/
	private bool leaveUnchanged(char[] c, int start, int end) {
   	int counter = 0;
		int tick = 0;
      bool check = false;
		for (int i = start; i <= end; i++) {
      	//count special characters
			if (notLetter(c[i]) && !(c[i] == 39)) {
         	counter++;
        	}
         //check for multiple ' in a word
			if (c[i] == 39) {
         	tick++;
         }
         //break loop upon termination condition
			if (counter != 0 || tick > 1) {
         	check = true;
         	break;
         }
		}
      return notAWord(c, start, end) || check;
	}  
      
   /**********************************************************************
	Checks if the incoming char array is not actually a word

	@param c: the char array to check
	@int start: the index of the first letter of the word
	@int end: the index of the last letter of the word
	@return bool: succeeds if the first letter > last letter or if index
					  of both are equal but notLetter succeeds.
	@see methods: notLetter, convert
	**********************************************************************/
	private bool notAWord(char[] c, int start, int end) {
      return (end == start && notLetter(c[start])) || (end < start);
      }
      
   /**********************************************************************
	Checks if the first letter is a vowel
	
	@param c: the character array to check
	@param start: the starting index of the word
	@param index: the index of the first vowel in the word
	@return book: succeeds if the first letter is a vowel
	@see method: convert
	**********************************************************************/
	private bool firstLetterVowel(char[] c, int start, int index) {
      return index == start && !(c[start] == 'Y' || c[start] == 'y');      
   }
      
   /*********************************************************************
	Appends the suffix 'way' to the incoming string.

	@param s: the incoming string
	@param end: the index of the last letter of the word
	@return string: the modified string to include 'way'
	@see methods: convert, lastLetterCaps
	**********************************************************************/
	private string useWay(string s, int end) {
      if (lastLetterCaps(s, end)) {
         return s.Insert(end + 1, "WAY");
      }
      else {
         return s.Insert(end + 1, "way");
      }
   }
      
   /*********************************************************************
	Appends the suffice 'ay' to the incoming string

	@param s: the incoming string
	@param end: the index of the last letter of the word
	@return string: the modified string to include 'ay'
	@see methods: convert, lastLetterCaps
	*********************************************************************/
	private string useAy(string s, int end) {
   	if (lastLetterCaps(s, end)) {
         return s.Insert(end + 1, "AY");
      }
      else {
         return s.Insert(end + 1, "ay");
      }
   }
      
   /*********************************************************************
	Checks if the last letter of a word is upper case
	<p>
	NOTE: did not use isCapital or isLowerCase above in order to demonstrate
			knowledge of string methods
	</p>

	@param s: the string to check
	@param end: the index of the last letter in the string
	@return book: succeeds if the last letter is upper case
	@see methods: useWay, useAy
	***********************************************************************/
	private bool lastLetterCaps(string s, int end) {
   	return s[end].ToString().Equals(s[end].ToString().ToUpper());
   }

   /********************************************************************
	Performs the iconic pig latin swap.

	<p>
	Specifically, moves the first consonant sound in a word to the end of
	said word, treating the letter 'y' as a vowel if not the first letter.
	</p>
	
	@param s: the string to modify
	@param start: the index of starting letter of the word
	@param end: the index of the ending letter of the word
	@param vowel: the index of the first vowel in the word
	@return string: the modified string
	@see methods: convert, isCpaital, swapCase
	*********************************************************************/
	private string swapLetters(string s, int start, int end, int vowel) {
      char[] c = s.ToCharArray();
      if (isCapital(c[start]) && !isCapital(c[vowel])) {
         c[start] = swapCase(c[start]);
         c[vowel] = swapCase(c[vowel]);
      }
      s = new string(c);
      string temp;
        temp = s.Substring(start, vowel - start);
        s = s.Insert(end + 1, temp);
        s = s.Remove(start, vowel - start);
        return s;      
   }
	//----------------------END FormPigLatin---------------------------
}
