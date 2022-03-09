
function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {

            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}
const cookieVal = getCookie("cartItem");
let productIds = cookieVal !== "" ? cookieVal.split("-") : [];

$(".btn-add-cart").click(function () {
    Swal.fire({
        title: 'Do you want add Product to Cart?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Save',
        denyButtonText: `Don't save`,
    }).then((result) => {
     
        if (result.isConfirmed) {
            Swal.fire('Saved!', '', 'success')
        } else if (result.isDenied) {
            Swal.fire('Changes are not saved', '', 'info')
        }
    })
      const productId = $(this).attr("pro-id");
      productIds.push(productId);
      console.log(productId)
      setCookie("cartItem", productIds.join("-"),4)
  })


$(".inc").on("click", function () {
    var oldvalue = $(this).parent().find("input").val();
    const price = $(this).parents(".cart-plus-minus").attr("pro-price");
    let totalPrice = 0;
    let quantity = parseFloat($(this).parents(".cart-plus-minus").find(".cart-plus-minus-box").val()) + 1;
    var productId = $(this).parents(".cart-plus-minus").attr("pro-id");
    if ($(this).text() == "+") {

        var newVal = parseFloat(oldvalue) + 1;

    }
    else {

        if (oldvalue > 0) {
            newVal = parseFloat(oldvalue);
        }
        else {
            newVal = 1;
        }
    }
    $(this).parent().find("input").val(newVal);
    productIds = productIds.filter(c => c !== productId);
    for (i = 0; i <= Number(oldvalue); i++) {
        productIds.push(productId);

    }
    setCookie("cartItem", productIds.join("-"), 4)
    $(this).parents("tr").find(".cart-product-subtotal").text("$" + ((parseFloat(price) * quantity)));
    let inputVal = $(this).parents(".tables tbody").find(".cart-product-subtotal").text();
    var allPrice = inputVal.split("$")
    console.log(allPrice)
    for (var i = 1; i < allPrice.length; i++) {
        totalPrice += parseFloat(allPrice[i]);
    }
    $(".shoping-cart-total .table .totalP").html(`$${totalPrice}`);
})
$(".dec").on("click", function () {
    let totalPrice = 0;
    var oldvalue = $(this).parent().find("input").val();
    const price = $(this).parents(".cart-plus-minus").attr("pro-price");
    let quantity = parseFloat($(this).parents(".cart-plus-minus").find(".cart-plus-minus-box").val()) - 1;
    var productId = $(this).parents(".cart-plus-minus").attr("pro-id");

    if (oldvalue == 1) {
        quantity=1
        //var newVal = parseFloat(oldvalue);
        $(this).disabled = true;
    }
    else {

        if (oldvalue > 1) {

            newVal = parseFloat(oldvalue) - 1;

        }

        console.log(newVal);    
    }
    $(this).parent().find("input").val(newVal);
    $(this).parents("tr").find("cart-product-subtotal").text(parseFloat(price) * quantity)
    productIds = productIds.filter(c => c !== productId);
    for (i = 0; i <= Number(oldvalue); i++) {
        productIds.push(productId);

    }
    setCookie("cartItem", productIds.join("-"), 4)
    $(this).parents("tr").find(".cart-product-subtotal").text("$" + ((parseFloat(price) * quantity)));
    let inputVal = $(this).parents(".tables tbody").find(".cart-product-subtotal").text();
    var allPrice = inputVal.split("$")
    console.log(allPrice)
    for (var i = 1; i < allPrice.length; i++) {
        totalPrice += parseFloat(allPrice[i]);
    }
    $(".shoping-cart-total .table .totalP").html(`$${totalPrice}`);
})



$(".btn-remove-cart").on("click", function (e) {
    e.preventDefault() 
    let totalPrice = 0;
    const productId = $(this).attr("pro-id");
    productIds = productIds.filter(p => p !== productId);
    setCookie("cartItem", productIds.join("-"), 4)
    $(this).parents("tr").remove();   
    let inputVal = $(this).parents(".tables tbody").find(".cart-product-subtotal").text();
    let allPrice = inputVal.split("$")
    console.log(allPrice)
    for (let i = 1; i < allPrice.length; i++) {
        totalPrice += parseFloat(allPrice[i]);
    }
    $(".shoping-cart-total .tables .totalP").html(`$${totalPrice}`);
  
    if ($(".carts .tables tbody tr").length == 0) {
        $(".cart-area .my-cart-area").html(`<p class="alert alert-danger">Sənin kartin işdəmir!</p>`)
    }
    console.log(productIds);
})