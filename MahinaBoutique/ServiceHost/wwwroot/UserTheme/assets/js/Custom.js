

const CookieName = "Item-cart" ;
function AddToCart(Id, Name, Price, Picture) {
    var Products = $.cookie(CookieName);
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
  
    var Products = $.cookie(CookieName);
    Products = JSON.parse(Products);
    $("#cart_item_count").text(Products.length)
    $("#cart_item_count_mobile").text(Products.length)
    
    var CartItems = $("#cart-item-wrapper")
    CartItems.html("")
    var CartItemsmobile = $("#cart-item-wrapper-mobile")
    CartItemsmobile.html("")

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
        CartItemsmobile.append(Product)
    }
        )
}

function RemoveCartItem(id) {
    var Products = $.cookie(CookieName);
    Products = JSON.parse(Products);
    const itemToRemove = Products.findIndex(x => x.id== id)
    Products.splice(itemToRemove,1)
    $.cookie(CookieName, JSON.stringify(Products),{expires:2,path:"/"})
    UpdateCart();
}

function ChangeProductCount(id, Totalprice, productCount) {
    
    var Products = $.cookie(CookieName);
    Products = JSON.parse(Products);
    var Selectedindex = Products.findIndex(x => x.Id == id);
    var SelectedProduct = Products[Selectedindex];
    SelectedProduct.ProductCount = parseInt(productCount);
    var unitprice = (SelectedProduct.UnitPrice).replace(/٬/g,'')
    $(`${Totalprice}`).text( parseInt(productCount) * parseInt(unitprice) )
    $.cookie(CookieName, JSON.stringify(Products),{expires:2,path:"/"})
    UpdateCart();

    const settings = {
        "url": "https://localhost:5001/api/Inventory",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({ "productId": id, "count": productCount })
    };
    
    $.ajax(settings).done(function (data) {
       
        if (data.inStock == false) {
            const warningsDiv = $('#productStockWarnings');
            if ($(`#${id}`).length == 0) {
                warningsDiv.append(`
                    <div class="alert alert-warning" id="${id}">
                        <i class="fa fa-warning"></i> کالای
                        <strong>${data.product}</strong>
                        در انبار کمتر از تعداد درخواستی موجود است.
                    </div>
                `);
            }
            
        } else {
            if ($(`#${id}`).length > 0) {
                $(`#${id}`).remove();
            }
        }
    });
}

