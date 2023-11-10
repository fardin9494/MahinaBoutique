

const CookieName = "Item-cart" ;
function AddToCart(id, Name, Price, Picture) {
    let Products = $.cookie(CookieName);
    if (Products === undefined) {
        Products = []
    } else {
        Products = JSON.parse(Products)
    }

    const ProductCount = $("#ProductCount").val();
    var CurrentProduct = Products.find(x => x.id === id)
    if (CurrentProduct !== undefined) {
        Products.find(x => x.id == id).ProductCount = parseInt(CurrentProduct.ProductCount) + parseInt(ProductCount)
    } else {
        const Product = {
            id,
            Name,
            Price,
            Picture,
            ProductCount,
        }
        Products.push(Product);
    }
    $.cookie(CookieName, JSON.stringify(Products),{expires:2,path:"/"})
    UpdateCart();
}

function UpdateCart() {
    let Products = $.cookie(CookieName);
    Products = JSON.parse(Products);
    $("#cart_item_count").text(Products.length)

    let CartItems = $("#cart-item-wrapper")
    CartItems.html("")

    Products.forEach(x => {
        const Product = ` <div class="single-cart-item">
                                                <a href="javascript:void(0)" class="remove-icon" onclick="RemoveCartItem('${x.id}')">
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
                                                        قیمت واحد : ${x.Price}
                                                    </p>
                                                </div>
                                            </div>`
        CartItems.append(Product)
    }
        )
}

function RemoveCartItem(id) {
    debugger;
    let Products = $.cookie(CookieName);
    Products = JSON.parse(Products);
    const itemToRemove = Products.findIndex(x => x.id== id)
    Products.splice(itemToRemove,1)
    $.cookie(CookieName, JSON.stringify(Products),{expires:2,path:"/"})
    UpdateCart();
}

