
/*Mis const perteneciente a PageOrders aqui empieza*/
const NewCustomerButton = document.querySelector("#NewCustomerButton")
const NewCustomerModal = document.querySelector("#NewCustomerModal")
const NewOrderForm = document.querySelector("#OrderForm")
const NewCustomerForm = document.querySelector("#CustomerFormModal")
const newOrderFormInputs = NewOrderForm.querySelectorAll('input')
const newCustomerFormInputs = NewCustomerForm.querySelectorAll('input')
/*Mis const perteneciente a PageOrders aqui termina*/

//Enlace al obj que va hacer el evento aqui empieza
NewCustomerButton.addEventListener("click", hadleNewCustomerClick)
NewOrderForm.addEventListener("submit", handleNewOrderFormSubmit)
NewCustomerForm.addEventListener("submit", handleNewCustomerFormSubmit)
/*Enlace al obj que va hacer el evento aqui termina*/









/*Funcion para eliminar la validacion al momento de escribir aqui comienza */
newOrderFormInputs.forEach(function (input) {
    input.addEventListener("input",function () {
        getErrorElement(input.name).textContent = ""
       
    })
})
/*Funcion para eliminar la validacion al momento de escribir aqui termina*/



/* validaciones para el form de order aqui empieza*/
function handleNewOrderFormSubmit(event) {
    event.preventDefault()

    const CustomerID = NewOrderForm.elements["InputCustomerID"]
    const EmployeeID = NewOrderForm.elements["InputEmployeeID"]
    const OrderDate = NewOrderForm.elements["OrderDate"]
    const RequiredDate = NewOrderForm.elements["RequiredDate"]
    const ShippedDate = NewOrderForm.elements["ShippedDate"]
    const ShipVia = NewOrderForm.elements["ShipVia"]
    const Freight = NewOrderForm.elements["Freight"]
    const ShipName = NewOrderForm.elements["ShipName"]
    const inputShipCountry = NewOrderForm.elements["inputShipCountry"]
    const ShipCity = NewOrderForm.elements["ShipCity"]
    const ShipRegion = NewOrderForm.elements["ShipRegion"]
    const ShipAddress = NewOrderForm.elements["ShipAddress"]
    const ShipPostalCode = NewOrderForm.elements["ShipPostalCode"]


    let isvalid = true

    if (CustomerID.value.trim() == "") {
        const errorElement = getErrorElement(CustomerID.name)
        errorElement.textContent="The customer ID is required"
        isValid = false;
    }

    if (EmployeeID.value.trim() == "") {
        const errorElement = getErrorElement(EmployeeID.name)
        errorElement.textContent = "The employee ID is required"
        isValid = false;
    }

    if (OrderDate.value.trim() == "") {
        const errorElement = getErrorElement(OrderDate.name)
        errorElement.textContent = "The order date is required"
        isValid = false;
    }

    if (RequiredDate.value.trim() == "") {
        const errorElement = getErrorElement(RequiredDate.name)
        errorElement.textContent = "The required date is required"
        isValid = false;
    }

    if (ShippedDate.value.trim() == "") {
        const errorElement = getErrorElement(ShippedDate.name)
        errorElement.textContent = "The shipped date is required"
        isValid = false;
    }

    if (ShipVia.value.trim() == "") {
        const errorElement = getErrorElement(ShipVia.name)
        errorElement.textContent = "The ship via is required"
        isValid = false;
    }

    if (Freight.value.trim() == "") {
        const errorElement = getErrorElement(Freight.name)
        errorElement.textContent = "The freight is required"
        isValid = false;
    }

    if (ShipName.value.trim() == "") {
        const errorElement = getErrorElement(ShipName.name)
        errorElement.textContent = "The ship name is required"
        isValid = false;
    }


    if (inputShipCountry.value.trim() == "") {
        const errorElement = getErrorElement(inputShipCountry.name)
        errorElement.textContent = "The ship country is required"
        isValid = false;
    }

    if (ShipCity.value.trim() == "") {
        const errorElement = getErrorElement(ShipCity.name)
        errorElement.textContent = "The ship city is required"
        isValid = false;
    }



    if (ShipRegion.value.trim() == "") {
        const errorElement = getErrorElement(ShipRegion.name)
        errorElement.textContent = "The ship region is required"
        isValid = false;
    }


    if (ShipAddress.value.trim() == "") {
        const errorElement = getErrorElement(ShipAddress.name)
        errorElement.textContent = "The address is required"
        isValid = false;
    }

    if (ShipPostalCode.value.trim() == "") {
        const errorElement = getErrorElement(ShipPostalCode.name)
        errorElement.textContent = "The ship postal code is required"
        isValid = false;
    }


    if (isValid) {

        //data validada
       
       
       

    }

}
/* validaciones para el form de order aqui termina*/




//Para tomar el errorElement en una funcion aqui empieza
function getErrorElement(inputName) {

    const element = document.querySelector(`.invalid-feedback[for='${inputName}']`)
    if (element) {
        return element
    }
    console.error(`Element with name '${inputName}' not found`)
}
//Para tomar el errorElement en una funcion aqui termina



/*para invocar el modal*/
function hadleNewCustomerClick() {
    const modal = new bootstrap.Modal(NewCustomerModal)
    modal.show();


}



/* validades para el modal de customer*/
function handleNewCustomerFormSubmit(event) {
    event.preventDefault()

    const InputCompanyName = NewCustomerForm.elements["InputCompanyName"]
    const InputContactName = NewCustomerForm.elements["InputContactName"]
    const InputContactTitle = NewCustomerForm.elements["InputContactTitle"]
    const InputPhone = NewCustomerForm.elements["InputPhone"]
    const InputFax = NewCustomerForm.elements["InputFax"]
    const InputCountry = NewCustomerForm.elements["InputCountry"]
    const InputAddress = NewCustomerForm.elements["InputAddress"]
    const InputRegion = NewCustomerForm.elements["InputRegion"]
    const InputZip = NewCustomerForm.elements["InputZip"]
    const InputCity = NewCustomerForm.elements["InputCity"]

    let isvalid = true

    if (InputCompanyName.value.trim() == "") {
        const errorElement = getErrorElement(InputCompanyName.name)
        errorElement.textContent = "The company name is required"
        isValid = false;
    }

    if (InputContactName.value.trim() == "") {
        const errorElement = getErrorElement(InputContactName.name)
        errorElement.textContent = "The contact name is required"
        isValid = false;
    }

    if (InputContactTitle.value.trim() == "") {
        const errorElement = getErrorElement(InputContactTitle.name)
        errorElement.textContent = "The contact title required"
        isValid = false;
    }

    if (InputPhone.value.trim() == "") {
        const errorElement = getErrorElement(InputPhone.name)
        errorElement.textContent = "The phone is required"
        isValid = false;
    }

    if (InputFax.value.trim() == "") {
        const errorElement = getErrorElement(InputFax.name)
        errorElement.textContent = "The fax is required"
        isValid = false;
    }

    if (InputCountry.value.trim() == "") {
        const errorElement = getErrorElement(InputCountry.name)
        errorElement.textContent = "The country is required"
        isValid = false;
    }

    if (InputAddress.value.trim() == "") {
        const errorElement = getErrorElement(InputAddress.name)
        errorElement.textContent = "The address is required"
        isValid = false;
    }

    if (InputRegion.value.trim() == "") {
        const errorElement = getErrorElement(InputRegion.name)
        errorElement.textContent = "The region is required"
        isValid = false;
    }

    if (InputZip.value.trim() == "") {
        const errorElement = getErrorElement(InputZip.name)
        errorElement.textContent = "The zip is required"
        isValid = false;
    }

    if (InputCity.value.trim() == "") {
        const errorElement = getErrorElement(InputCity.name)
        errorElement.textContent = "The zip is required"
        isValid = false;
    }



    if (isValid ) {

        //data validada

    }

}
/* validades paera el modal de customer*/


/*Funcion para eliminar la validacion al momento de escribir en el customer aqui comienza */
newCustomerFormInputs.forEach(function (input) {
    input.addEventListener("input",function () {
        getErrorElement(input.name).textContent = ""

    })
})
/*Funcion para eliminar la validacion al momento de escribir en el customer aqui termina*/


/*funcion para eliminar los error una vez vuelva a cargar el formulario modal aqui empieza*/
NewCustomerModal.addEventListener('hidden.bs.modal', function (event) {
    newCustomerFormInputs.forEach(function (input, select) {
        input.value = ""
        getErrorElement(input.name).textContent = ""
    })
})

/*funcion para eliminar los error una vez vuelva a cargar el formulario modal aqui termina*/