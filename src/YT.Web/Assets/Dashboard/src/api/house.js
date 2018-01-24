import fetch from 'utils/fetch';
export function getHouses(data) {
    return fetch({
        url: '/api/services/app/wareHouse/GetPagedWareHousesAsync',
        method: 'post',
        data
    });
}

export function getHouseEdit(data) {
    return fetch({
        url: '/api/services/app/wareHouse/GetWareHouseForEditAsync',
        method: 'post',
        data
    });
}
export function getHouse(data) {
    return fetch({
        url: '/api/services/app/wareHouse/GetWareHouseByIdAsync',
        method: 'post',
        data
    });
}
export function modifyHouse(data) {
    return fetch({
        url: '/api/services/app/wareHouse/CreateOrUpdateWareHouseAsync',
        method: 'post',
        data
    });
}
export function deleteHouse(data) {
    return fetch({
        url: '/api/services/app/wareHouse/DeleteWareHouseAsync',
        method: 'post',
        data
    });
}
export function deleteHouses(data) {
    return fetch({
        url: '/api/services/app/wareHouse/BatchDeleteWareHouseAsync',
        method: 'post',
        data
    });
}
export function exportHouse(data) {
    return fetch({
        url: '/api/services/app/wareHouse/GetWareHouseToExcel',
        method: 'post',
        data
    });
}