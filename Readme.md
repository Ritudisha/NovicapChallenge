# Novicap - A Console App written in C#

The app is a dot net core console app. Therefore needs dot net v4.6.

Instructions:
- Kindly clone the repository.
- Open in vs code and install the dependencies -> dot net core framework v4.6.
- After installation, execute using ```dotnet bin\Debug\netcoreapp3.1\Novicap.dll VOUCHER VOUCHER TSHIRT MUG VOUCHER TSHIRT TSHIRT```
 The inputs are provided with space separator. 
 
 The code is using newtonsoft library to add json functionalities.
 
 There are 3 main files:
 
 - DiscountModel.cs:  This file contains the discount type models along with the properties and a method to calculate the price 
                        amount by accepting quantity and the actual price as the parameter. Whenever a new discount type is added, 
                        a new model along with it's functionality should be added.
                        
 - ProductConfig.json: This file is the json file that the sales department can update anytime. 
                        The json file format is a list of a user defined object type defined in file "ProductConfig.cs"
                        The Discount Object is of respective discount type that is applied on the product. 
                        
  - Invoice.cs: This is the file that provides the checkout and get total amount functionalities. 
                  So, the main function calls this function to calculate the total amount.
                  The Method returns the calculated amount after applying respective discount.
                  It accepts two inputs : 
                  
                      1. The json file path.
                      2. The list of product codes
                  
