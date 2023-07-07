// Provider modal
const providerModal = document.querySelector("#searchProviderModal");
const providerModalBody = providerModal.getElementsByClassName("modal-body")[0];
const providerResultTable = providerModal.getElementsByTagName("tbody")[0];

// Provider inputs
const providerIdInput = document.getElementById("providerId");
const providerDescriptionInput = document.getElementById("providerDescription");

// Product table
const productsTable = document.querySelector("#productTable");
const productsTableBody = productsTable.getElementsByTagName("tbody")[0];

// Product modal
const productModal = document.querySelector("#searchProductModal");
const productModalBody = productModal.getElementsByClassName("modal-body")[0];
const productResultTable = productModal.getElementsByTagName("tbody")[0];

// Product inputs
const selectProductBtn = document.getElementById("selectProduct");

// Search Provider events
providerModal.getElementsByTagName("form")[0].addEventListener("submit", function(e) {
    e.preventDefault();

    const searchValue = this.providerByName.value?.trim();
    if (!searchValue)
        return;

    // Removing old rows
    while (providerResultTable.hasChildNodes())
        providerResultTable.removeChild(providerResultTable.firstChild)
        
    // Waiting
    const spinner = makeWaitSpinner();
    providerModalBody.appendChild(spinner);
    
    sendRequest(`/Proveedor/GetProveedores?expresion=${searchValue}`, "GET")
        // Removing the spinner
        .then(res => {
            providerModalBody.removeChild(spinner);
            return res;
        })
        .then(res => {
            // Adding rows with information
            res.forEach(provider => {
                providerResultTable.appendChild(createRowResult(
                    { 
                        id: provider.Id,
                        documentNumber: provider.NumeroDocumento,
                        name: provider.NombreCompleto
                    },
                    providerResultTable
                ));
            })
        })
        .catch(err => {
            alert(`Ups! -> ${err}`)
        });
});


document.getElementById("selectProvider").addEventListener("click", e => {
    let selected = null;

    if (!providerResultTable.hasChildNodes()) {
        alert("Debe seleccionar un proveedor!");
        return;
    }

    for (let row of providerResultTable.rows) {
        if (row.dataset.selected === "true") {
            selected = row;
            break;
        }
    }

    if (!selected) {
        alert("Debe seleccionar un proveedor!");
        return;
    }

    // Store in the provider input
    const providerId = selected.children[0].textContent;
    const providerDescription = `${selected.children[1].textContent} - ${selected.children[2].textContent}`;
    providerIdInput.value = providerId;
    providerDescriptionInput.value = providerDescription;

    // Hiding modal
    $("#searchProviderModal").modal("hide");
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

    productNewRow.appendChild(createTableInput("text", "d-none", true, true)); // Id
    productNewRow.appendChild(createTableInput("text", "form-control", true, false, "Buscar Producto...")); // Code
    productNewRow.appendChild(createTableInput("text", "form-control", true, false, "Buscar Producto...")); // Description
    productNewRow.appendChild(createTableInput("number", "form-control", false)); // Price Buy
    productNewRow.appendChild(createTableInput("number", "form-control", false)); // Price Sell
    productNewRow.appendChild(createTableInput("number", "form-control", false)); // Quantity

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
    
    sendRequest(`/Producto/GetProductos?expresion=${searchValue}`, "GET")
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
                        description: producto.Descripcion
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

    productIdFromRowInput.value = selected.children[0].textContent;
    productCodeFromRowInput.value = selected.children[1].textContent;
    productDescriptionFromRowInput.value = selected.children[2].textContent;
        
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

    const providerId = providerIdInput.value?.toString().trim();
    if (!isNotNullOrEmpty(providerId)) {
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
        const productIdToAdd = row.children[1].firstElementChild.value;
        const unitPurchasePrice = row.children[4].firstElementChild.value;
        const unitSalePrice = row.children[5].firstElementChild.value;
        const quantity = row.children[6].firstElementChild.value;

        if (!isNotNullOrEmpty(productIdToAdd) || !isNotNullOrEmpty(unitPurchasePrice) || !isNotNullOrEmpty(unitSalePrice) || !isNotNullOrEmpty(quantity)) {
            alert("Todos los campos de cada producto debe completarse!");
            return;
        }

        products.push({
            productId: Number(productIdToAdd),
            unitPurchasePrice: Number(unitPurchasePrice),
            unitSalePrice: Number(unitSalePrice),
            quantity: Number(quantity)
        });
    }

    e.target.disabled = true;

    sendRequest("/Inventario/Entrada/Create", "POST", {
        registerDate,
        providerId,
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
                providerIdInput.value = "";
                providerDescriptionInput.value = "";
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
