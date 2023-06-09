# CSV-Injection-validation
CSV Injection, also known as Formula Injection, occurs when websites embed untrusted input inside CSV files.

When a spreadsheet program such as Microsoft Excel or LibreOffice Calc is used to open a CSV, any cells starting with = will be interpreted by the software as a formula. Maliciously crafted formulas can be used for three key attacks:

* Hijacking the user’s computer by exploiting vulnerabilities in the spreadsheet software, such as CVE-2014-3524.
* Hijacking the user’s computer by exploiting the user’s tendency to ignore security warnings in spreadsheets that they downloaded from their own website.
* Exfiltrating contents from the spreadsheet, or other open spreadsheets.

This attack is difficult to mitigate, and explicitly disallowed from quite a few bug bounty programs. To remediate it, ensure that no cells begin with any of the following characters:

* Equals to (=)
* Plus (+)
* Minus (-)
* At (@)
* Tab (0x09)
* Carriage return (0x0D)

Keep in mind that it is not sufficient to make sure that the untrusted user input does not start with these characters. You also need to take care of the field separator (e.g., ‘,’, or ‘;’) and quotes (e.g., ', or "), as attackers could use this to start a new cell and then have the dangerous character in the middle of the user input, but at the beginning of a cell.

So I will update a code for try to validate.
