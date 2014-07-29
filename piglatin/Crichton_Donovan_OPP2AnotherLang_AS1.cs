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

    //initialise the form components for use
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
        this.tbxEnglish.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
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
      this.tbxPigLatin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.Name = "tbxPigLatin";

      //Translate button
      this.btnTranslate.Location = new Point(leftPos, height 
         - btnHeight - bottomPos);
      this.btnTranslate.Size = new Size(btnWidth, btnHeight);
      this.btnTranslate.Font = new Font(FontFamily.GenericSansSerif, 12);
      this.btnTranslate.Text = "Translate";
      this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);

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
        //this.ResumeLayout(false);
    }

    [STAThread]
    static void Main() {
        //set window style to current windows theme
        Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new FormPigLatin());
    }

   //exit upon click
   private void btnExit_Click(object sender, System.EventArgs e) {
      Application.Exit();
   }

   //clear upon click
   private void btnClear_Click(object sender, System.EventArgs e) {
      tbxEnglish.Text = "";
      tbxPigLatin.Text = "";
   }

   //translate upon click
   private void btnTranslate_Click(object sender, System.EventArgs e) {
      tbxPigLatin.Text = translate(tbxEnglish.Text);
   }

   //splits the text in tbxEnglish into an array, loops over it, and then calls convert for
   //each entry in the array. rejoins the string upon completion. 
   private string translate(string s) {
      string[] delimiter = new string[] {" "};
      string[] sArray = s.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
      for (int i = 0; i < sArray.Length; i++) {
         sArray[i] = convert(sArray[i]);
      }
      return String.Join(" ", sArray);
   }

   //executes the actual pig latin translation logic
   private string convert(string s) {
      //declare conversion variables
      int wordStart = 0;
      int wordEnd = 0;
      int vowelIndex = 0;
      int counter = 0;
      int tick = 0;
      string temp = null;
      char[] vowels = new char[] {'A', 'E', 'I', 'O', 'U', 'Y'};
      char[] c = new char[s.Length];

      //initialise character array to allow manipulation 
      c = s.ToCharArray();
      //check for pre-word non-letter symbols
      while (notLetter(c[counter]) && counter < c.Length - 1) {
         counter++;
      }   
      wordStart = counter;
      counter = c.Length - 1;
      //check for post-word non-letter symbols
      while (notLetter(c[counter]) && counter > 0 ) {
         counter--;
      }
      wordEnd = counter;
      //reset counter
      counter = 0;
      //not a real word
      if ((wordEnd == wordStart && notLetter(c[wordStart])) || wordEnd < wordStart) {
         return s;
      }
      else {
         //get first vowel
         vowelIndex = s.ToUpper().IndexOfAny(vowels);
         //if the first letter is a vowel
         if (vowelIndex == wordStart && !(c[wordStart] == 'Y' || c[wordStart] == 'y')) {
            s = s.Insert(wordEnd + 1, "way");
            return s;
         }
         
         
         else {
            //if the word has no vowels, use 'ay'
            if (vowelIndex == -1) {
               s = s.Insert(wordEnd + 1, "ay");
               return s;
            }
            
            //ensure correct capitalisation
            if (isCapital(c[wordStart])) {
               c[wordStart] = swapCase(c[wordStart]);
               c[vowelIndex] = swapCase(c[vowelIndex]);
            }
            
            //keep words with non apostrophe symbols unchanged
            for (int i = wordStart; i <= wordEnd; i++) {
               if (notLetter(c[i]) && !(c[i] == 39)) {
                  counter++;
               }
               if (c[i] == 30) {
                  tick++;
               }
               if (counter != 0 || tick > 1) {
                  return s;
               }
            }
            //regular translation
            s = new string(c);
            //used to avoid bug - probably needs a rewrite
            if (c[wordStart] == 'y' || c[wordStart] =='Y') {
               vowelIndex = 1;
            }
            temp = s.Substring(wordStart, vowelIndex - wordStart);
            System.Console.WriteLine(temp);
            s = s.Insert(wordEnd + 1, temp + "ay");
            s = s.Remove (wordStart, vowelIndex - wordStart);
            return s;
         }
      }
   }
   
   // C# ASCII code for lower and upper bounds of capital letters
   private bool isCapital(char c) {
      return (c > 64 && c < 91);
   }

   // C# ASCII code for lower and upper bounds of lower case letters
   private bool isLowerCase(char c) {
      return (c > 96 && c < 123);
   }

   private bool notLetter(char c) {
      return (!(isCapital(c) || isLowerCase(c)));
   }

   // 32 is the difference between the same upper and lower case letter in C# ASCII
   private char swapCase(char c) {
      if (isLowerCase(c)) {
         return (char) ((int) c - 32);
      } 
      else if (isCapital(c)) {
         return (char) ((int) c + 32);
      }
      else return ' ';
   }
}
