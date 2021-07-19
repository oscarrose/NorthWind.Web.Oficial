
const orderDetailTable = document.querySelector("#orderDetailTable")
const addProductButton = document.querySelector("#addProductButton")
const newProductSelect = document.querySelector("#newProductSelect")
const newProductQuantity = document.querySelector("#newProductQuantity")
const newProductDiscount = document.querySelector("#newProductDiscount")

const orderDetailTemplate = document.querySelector("#orderDetailTemplate")

addProductButton.addEventListener("click", onAddProductButtonClick)


function createOrderDetailItem(product) {

    let quantity = "1"
    let discount = ""

    if (numeral(newProductQuantity.value).value() != null) {
        quantity = numeral(newProductQuantity.value).value();
    }

    if (numeral(newProductDiscount.value).value() != null) {
        discount = numeral(newProductDiscount.value).value()
    }

    const rowHTML = orderDetailTemplate.innerHTML
        .replace(new RegExp("{guid}", "g"), Date.now())
        .replace(new RegExp("{productId}", "g"), product.productID)
        .replace(new RegExp("{productName}", "g"), product.productName)
        .replace(new RegExp("{unitPrice}", "g"), formatNumber(product.unitPrice))
        .replace(new RegExp("{unitPriceWithFormat}", "g"), formatNumber(product.unitPrice))
        .replace(new RegExp("{quantity}", "g"), quantity)
        .replace(new RegExp("{discount}", "g"), discount)
        .replace(new RegExp("{total}", "g"), 0)
        .trim();

    newProductSelect.value = ""
    newProductQuantity.value = "";
    newProductDiscount.value = "";

    const tempTBody = document.createElement("tbody");
    tempTBody.innerHTML = rowHTML;

    updateTotal(tempTBody.firstChild)

    tempTBody.querySelector(".quantityInput").addEventListener("keyup", onQuantityInputKeyUp)
    tempTBody.querySelector(".discountInput").addEventListener("keyup", onQuantityInputKeyUp)

    orderDetailTable.querySelector("tbody")
        .appendChild(tempTBody.firstChild)

}

function onAddProductButtonClick() {

    if (newProductSelect.value == "") {
        Swal.fire({
            title: 'Agregar producto',
            text: 'Debe seleccionar un producto',
            icon: 'info',
            confirmButtonText: 'Ok'
        })

        return;
    }

    const productId = newProductSelect.value;
    fetch("/Orders/NewOrder?handler=ProductInfo&id=" + productId)
        .then(res => res.json())
        .then(product => {
            createOrderDetailItem(product)
        })
}

function onQuantityInputKeyUp(event) {
    const quantityInput = event.target;
    const tableRow = quantityInput.parentNode.parentNode;
    updateTotal(tableRow)

}

function onDiscountInputKeyUp(event) {
    const discountInput = event.target;
    const tableRow = discountInput.parentNode.parentNode;
    updateTotal(tableRow)
}

function updateTotal(tableRow) {

    const discountInput = tableRow.querySelector(".discountInput")

    const unitPrice = parseFloat(tableRow.querySelector(".unitPriceInput").value)
    const quantity = parseFloat(tableRow.querySelector(".quantityInput").value);

    let total = unitPrice * quantity;

    if (numeral(discountInput.value) != null) {
        const discount = numeral(discountInput.value).value()
        const discountAmount = (discount / 100) * total;
        total = total - discountAmount;
    }

    tableRow.querySelector('.totalInput').value = total;
    tableRow.querySelector('.total')
        .textContent = formatNumber(total)
}

function formatNumber(number) {
    return numeral(number).format('0,0.00')
}