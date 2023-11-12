

const CookieName = "Item-cart" ;
function AddToCart(Id, Name, Price, Picture) {
    let Products = $.cookie(CookieName);
    if (Products === undefined) {
        Products = []
    } else {
        Products = JSON.parse(Products)
    }

    const ProductCount = $("#ProductCount").val();
    var CurrentProduct = Products.find(x => x.Id === Id)
    if (CurrentProduct !== undefined) {
        Products.find(x => x.Id == Id).ProductCount = parseInt(CurrentProduct.ProductCount) + parseInt(ProductCount)
    } else {
        const Product = {
            Id,
            Name,
            UnitPrice : Price,
            Picture,
            ProductCount,
        }
        Products.push(Product);
    }
    $.cookie(CookieName, JSON.stringify(Products),{expires:2,path:"/"})
    UpdateCart();
}

function UpdateCart() {
    debugger
    let Products = $.cookie(CookieName);
    Products = JSON.parse(Products);
    $("#cart_item_count").text(Products.length)

    let CartItems = $("#cart-item-wrapper")
    CartItems.html("")

    Products.forEach(x => {
        const Product = ` <div class="single-cart-item">
                                                <a href="javascript:void(0)" class="remove-icon" onclick="RemoveCartItem('${x.Id}')">
                                                    <i class="ion-android-close"></i>
                                                </a>
                                                <div class="image">
                                                    <a href="single-product.html">
                                                        <img src="/ProductPictures/${x.Picture}"
                                                             class="img-fluid" alt="">
                                                    </a>
                                                </div>
                                                <div class="content">
                                                    <p class="product-title">
                                                        <a href="single-product.html">نام محصول : ${x.Name}</a>
                                                    </p>
                                                    <p class="count"><span>تعداد : ${x.ProductCount}</span></p>
                                                    <p class="product-title">
                                                        قیمت واحد : ${x.UnitPrice}
                                                    </p>
                                                </div>
                                            </div>`
        CartItems.append(Product)
    }
        )
}

function RemoveCartItem(id) {
    let Products = $.cookie(CookieName);
    Products = JSON.parse(Products);
    const itemToRemove = Products.findIndex(x => x.id== id)
    Products.splice(itemToRemove,1)
    $.cookie(CookieName, JSON.stringify(Products),{expires:2,path:"/"})
    UpdateCart();
}

function ChangeProductCount(id, Totalprice, productCount) {
    debugger;
    let Products = $.cookie(CookieName);
    Products = JSON.parse(Products);
    var Selectedindex = Products.findIndex(x => x.Id == id);
    var SelectedProduct = Products[Selectedindex];
    SelectedProduct.ProductCount = parseInt(productCount);
    var unitprice = (SelectedProduct.UnitPrice).replace(/٬/g,'')
    $(`${Totalprice}`).text( parseInt(productCount) * parseInt(unitprice) )
    $.cookie(CookieName, JSON.stringify(Products),{expires:2,path:"/"})
    UpdateCart();

}

