// Client modal
const clientModal = document.querySelector("#searchClientModal");
const clientModalBody = clientModal.getElementsByClassName("modal-body")[0];
const clientResultTable = clientModal.getElementsByTagName("tbody")[0];

// Client inputs
const clientIdInput = document.getElementById("clientId");
const clientDescriptionInput = document.getElementById("clientDescription");

// Product table
const productsTable = document.querySelector("#productTable");
const productsTableBody = productsTable.getElementsByTagName("tbody")[0];

// Product modal
const productModal = document.querySelector("#searchProductModal");
const productModalBody = productModal.getElementsByClassName("modal-body")[0];
const productResultTable = productModal.getElementsByTagName("tbody")[0];

// Product inputs
const selectProductBtn = document.getElementById("selectProduct");

// Search Client events
clientModal.getElementsByTagName("form")[0].addEventListener("submit", function(e) {
    e.preventDefault();

    const searchValue = this.clientByName.value?.trim();
    if (!searchValue)
        return;

    // Removing old rows
    while (clientResultTable.hasChildNodes())
        clientResultTable.removeChild(clientResultTable.firstChild)
        
    // Waiting
    const spinner = makeWaitSpinner();
    clientModalBody.appendChild(spinner);
    
    sendRequest(`/Cliente/GetClientes?expresion=${searchValue}`, "GET")
        // Removing the spinner
        .then(res => {
            clientModalBody.removeChild(spinner);
            return res;
        })
        .then(res => {
            // Adding rows with information
            res.forEach(client => {
                clientResultTable.appendChild(createRowResult(
                    { 
                        id: client.Id,
                        documentNumber: client.NumeroDocumento,
                        name: client.NombreCompleto
                    },
                    clientResultTable
                ));
            })
        })
        .catch(err => {
            alert(`Ups! -> ${err}`)
        });
});


document.getElementById("selectClient").addEventListener("click", e => {
    let selected = null;

    if (!clientResultTable.hasChildNodes()) {
        alert("Debe seleccionar un cliente!");
        return;
    }

    for (let row of clientResultTable.rows) {
        if (row.dataset.selected === "true") {
            selected = row;
            break;
        }
    }

    if (!selected) {
        alert("Debe seleccionar un cliente!");
        return;
    }

    // Store in the client input
    const clientId = selected.children[0].textContent;
    const clientDescription = `${selected.children[1].textContent} - ${selected.children[2].textContent}`;
    clientIdInput.value = clientId;
    clientDescriptionInput.value = clientDescription;

    // Hiding modal
    $("#searchClientModal").modal("hide");
});


// Products events
document.querySelector("#addProduct").addEventListener("click", e => {
    const productNewRow = document.createElement("tr");
    const buttonContainer = document.createElement("td");

    const lockButton = createButton("lock", "primary");
    const trashButton = createButton("trash", "danger");
    const searchButton = createButton("search", "secondary");

    lockButton.addEventListener("click", function (e) {
        console.log("lock");
    });

    trashButton.addEventListener("click", function (e) {
        let targetElement = e.target.parentElement.parentElement;
        if (targetElement.nodeName === "TD") {
            targetElement = targetElement.parentElement;
        }

        targetElement.remove();

        // Update dataid
        for (var i = 0; i < productsTableBody.children.length; i++) {
            productsTableBody.children[i].dataset.id = i + 1;
        }
    });

    searchButton.addEventListener("click", function (e) {
        let targetElement = e.target.parentElement.parentElement;
        if (targetElement.nodeName === "TD") {
            targetElement = targetElement.parentElement;
        }

        // Open modal
        selectProductBtn.dataset.from_id = targetElement.dataset.id;
        $("#searchProductModal").modal("show");
    });

    buttonContainer.appendChild(trashButton);
    buttonContainer.appendChild(lockButton);
    buttonContainer.appendChild(searchButton);

    productNewRow.dataset.locked = false
    productNewRow.dataset.id = productsTableBody.children.length + 1;
    productNewRow.appendChild(buttonContainer);

    const showPrices = e => {
        const quantityInput = e.target;
        const stockInput = quantityInput.parentElement.previousElementSibling.firstElementChild;
        const unitPriceInput = stockInput.parentElement.previousElementSibling.firstElementChild;
        const totalPriceInput = quantityInput.parentElement.nextElementSibling.firstElementChild;

        if (stockInput.value == "")
            return;

        if (Number(quantityInput.value) > Number(stockInput.value)) {
            quantityInput.value = stockInput.value;
        }

        totalPriceInput.value = Number(unitPriceInput.value) * Number(quantityInput.value);
    }

    productNewRow.appendChild(createTableInput({ type: "text", className: "d-none" }, true)); // Id
    productNewRow.appendChild(createTableInput({ type: "text", className: "form-control", placeholder: "000000", readOnly: true })); // Code
    productNewRow.appendChild(createTableInput({ type: "text", className: "form-control", placeholder: "Descripcion...", readOnly: true })); // Description
    productNewRow.appendChild(createTableInput({ type: "number", className: "form-control", placeholder: "S/. 0.00", readOnly: true })); // Price Sell
    productNewRow.appendChild(createTableInput({ type: "number", className: "form-control", placeholder: "0", readOnly: true })); // Stock
    productNewRow.appendChild(createTableInput({ type: "number", className: "form-control", min: 1, onchange: showPrices })); // Quantity
    productNewRow.appendChild(createTableInput({ type: "number", className: "form-control", placeholder: "S/. 0.00", readOnly: true })); // Total Price

    productsTableBody.appendChild(productNewRow);
});

productModal.getElementsByTagName("form")[0].addEventListener("submit", function(e) {
    e.preventDefault();

    const searchValue = this.productByDescription.value?.trim();
    if (!searchValue)
        return;

    // Removing old rows
    while (productResultTable.hasChildNodes())
        productResultTable.removeChild(productResultTable.firstChild)
        
    // Waiting
    const spinner = makeWaitSpinner();
    productModalBody.appendChild(spinner);
    
    sendRequest(`/Producto/GetProductosConStock?descripcion=${searchValue}`, "GET")
        // Removing the spinner
        .then(res => {
            productModalBody.removeChild(spinner);
            return res;
        })
        .then(res => {
            // Adding rows with information
            res.forEach(producto => {
                productResultTable.appendChild(createRowResult(
                    { 
                        id: producto.Id,
                        code: producto.Codigo,
                        description: producto.Descripcion,
                        unitSellPrice: producto.UltimoPrecioVenta,
                        stock: producto.Stock,
                    },
                    productResultTable
                ));
            })
        })
        .catch(err => {
            alert(`Ups! -> ${err}`)
        });
});


selectProductBtn.addEventListener("click", e => {
    let selected = null;

    if (!productResultTable.hasChildNodes()) {
        alert("Debe seleccionar un producto!");
        return;
    }

    for (let row of productResultTable.rows) {
        if (row.dataset.selected === "true") {
            selected = row;
            break;
        }
    }

    if (!selected) {
        alert("Debe seleccionar un producto!");
        return;
    }

    // Search origin producto selected
    const fromProductId = selectProductBtn.dataset.from_id;

    // Check if the selected product exits in the table list
    for (let row of productsTableBody.rows) {
        if (row.children[1].firstElementChild.value == selected.children[0].textContent) {
            alert("Este producto ya está agregado!");
            return;
        }

        if (row.dataset.id == fromProductId) {
            productSelectedToSearch = row;
        }
    }


    if (!productSelectedToSearch) {
        alert("No se pudó agregar el producto")
        return;
    }

    // Set the product row selected to the row fields in the table
    const productIdFromRowInput = productSelectedToSearch.children[1].firstElementChild;
    const productCodeFromRowInput = productSelectedToSearch.children[2].firstElementChild;
    const productDescriptionFromRowInput = productSelectedToSearch.children[3].firstElementChild;
    const productUnitSellPriceFromRowInput = productSelectedToSearch.children[4].firstElementChild;
    const productStockFromRowInput = productSelectedToSearch.children[5].firstElementChild;

    productIdFromRowInput.value = selected.children[0].textContent;
    productCodeFromRowInput.value = selected.children[1].textContent;
    productDescriptionFromRowInput.value = selected.children[2].textContent;
    productUnitSellPriceFromRowInput.value = selected.children[3].textContent;
    productStockFromRowInput.value = selected.children[4].textContent;

    productSelectedToSearch.children[6].firstElementChild.value = 1; // Quanitity
    productSelectedToSearch.children[7].firstElementChild.value = Number(productUnitSellPriceFromRowInput.value); // Price
        
    // Hiding modal
    $("#searchProductModal").modal("hide");
});


/*********************  REGISTER PRODUCT ************************* */
document.getElementById("register").addEventListener("click", e => {
    const registerDate = document.getElementById("fechaRegistro").value?.toString().trim();
    if (!isNotNullOrEmpty(registerDate)) {
        alert("Debe colocar una fecha de registro");
        return;
    }

    const clientId = clientIdInput.value?.toString().trim();
    if (!isNotNullOrEmpty(clientId)) {
        alert("Debe colocar un proveedor");
        return;
    }

    // Check if exists products
    if (productsTableBody.rows.length === 0) {
        alert("Debe agregar por lo menos un producto!");
        return;
    } 

    const products = []
    // Valid all products' fields that are complete
    for (let row of productsTableBody.rows) {
        const productIdToAdd = row.children[1].firstElementChild.value; // ProductId
        const unitSalePrice = row.children[4].firstElementChild.value; // UnitPrice
        const quantity = row.children[6].firstElementChild.value; // Quantity

        if (!isNotNullOrEmpty(productIdToAdd) || !isNotNullOrEmpty(unitSalePrice) || !isNotNullOrEmpty(quantity)) {
            alert("Todos los campos de cada producto debe completarse!");
            return;
        }

        products.push({
            productId: Number(productIdToAdd),
            unitSalePrice: Number(unitSalePrice),
            quantity: Number(quantity)
        });
    }

    e.target.disabled = true;

    sendRequest("/Inventario/Salida/Create", "POST", {
        registerDate,
        clientId,
        products
    })
        .then(res => {
            e.target.disabled = false;
            return res;
        })
        .then(res => {
            const { status, message } = res;
            let style = "danger";
            if (status) {
                // Clean Inputs
                document.getElementById("fechaRegistro").value = "";
                clientIdInput.value = "";
                clientDescriptionInput.value = "";
                while (productsTableBody.hasChildNodes())
                    productsTableBody.removeChild(productsTableBody.firstChild);

                style = "success";
            } 

            showMessage(message, style, document.querySelector("#mainContainerMessage"));
        })
        .catch(err => {
            alert(`Ups! Ocurrio un error, vuelva a intentarlo!`);
        })
});
