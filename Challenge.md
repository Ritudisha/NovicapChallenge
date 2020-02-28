##### Besides providing invoice finance, NoviCap also runs a physical store which sells (only) 3 products:

``` 
Code         | Name                |  Price
-------------------------------------------------
VOUCHER      | NoviCap Voucher      |   5.00€
TSHIRT       | NoviCap T-Shirt      |  20.00€
MUG          | NoviCap Coffee Mug   |   7.50€
```

Various departments have insisted on the following discounts:

 * The marketing department believes in 2-for-1 promotions (buy two of the same product, get one free), and would like for there to be a 2-for-1 special on `VOUCHER` items.

 * The CFO insists that the best way to increase sales is with discounts on bulk purchases (buying x or more of a product, the price of that product is reduced), and demands that if you buy 3 or more `TSHIRT` items, the price per unit should be 19.00€.

NoviCap's checkout process allows for items to be scanned in any order, and should return the total amount to be paid. The interface for the checkout process looks like this (ruby):

```ruby
co = Checkout.new(pricing_rules)
co.scan("VOUCHER")
co.scan("VOUCHER")
co.scan("TSHIRT")
price = co.total
```

Our sales team is constantly adding, removing, and repricing products, so they should be configurable with a json file.

Examples:

    Items: VOUCHER, TSHIRT, MUG
    Total: 32.50€

    Items: VOUCHER, TSHIRT, VOUCHER
    Total: 25.00€

    Items: TSHIRT, TSHIRT, TSHIRT, VOUCHER, TSHIRT
    Total: 81.00€

    Items: VOUCHER, TSHIRT, VOUCHER, VOUCHER, MUG, TSHIRT, TSHIRT
    Total: 74.50€

**The code should:**
- Be written as production-ready code. You will write production code.
- Be easy to grow and easy to add new functionality.
- Have notes attached, explaning the solution and why certain things are included and others are left out.
- Be written in a language you are comforable with as we will do pair programming on your submission in subsequent interviews
- Be as simple as possible. We value clean, minimal, well-designed code; no points for showing off.
