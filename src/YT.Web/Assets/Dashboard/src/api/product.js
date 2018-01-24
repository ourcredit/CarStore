import fetch from 'utils/fetch';
export function getProducts(data) {
    return fetch({
        url: '/api/services/app/Product/GetPagedProductsAsync',
        method: 'post',
        data
    });
}

export function getProductEdit(data) {
    return fetch({
        url: '/api/services/app/Product/GetProductForEditAsync',
        method: 'post',
        data
    });
}
export function getProduct(data) {
    return fetch({
        url: '/api/services/app/Product/GetProductByIdAsync',
        method: 'post',
        data
    });
}
export function modifyProduct(data) {
    return fetch({
        url: '/api/services/app/Product/CreateOrUpdateProductAsync',
        method: 'post',
        data
    });
}
export function deleteProduct(data) {
    return fetch({
        url: '/api/services/app/Product/DeleteProductAsync',
        method: 'post',
        data
    });
}
export function deleteProducts(data) {
    return fetch({
        url: '/api/services/app/Product/BatchDeleteProductAsync',
        method: 'post',
        data
    });
}
export function exportProduct(data) {
    return fetch({
        url: '/api/services/app/Product/GetProductToExcel',
        method: 'post',
        data
    });
}