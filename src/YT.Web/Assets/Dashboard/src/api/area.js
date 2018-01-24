import fetch from 'utils/fetch';
export function getAreas(data) {
    return fetch({
        url: '/api/services/app/area/GetPagedAreasAsync',
        method: 'post',
        data
    });
}
export function getAllAreas() {
    return fetch({
        url: '/api/services/app/area/GetAllAreas',
        method: 'post'
    });
}
export function getAreaEdit(data) {
    return fetch({
        url: '/api/services/app/area/GetAreaForEditAsync',
        method: 'post',
        data
    });
}
export function getArea(data) {
    return fetch({
        url: '/api/services/app/area/GetAreaByIdAsync',
        method: 'post',
        data
    });
}
export function modifyArea(data) {
    return fetch({
        url: '/api/services/app/area/CreateOrUpdateAreaAsync',
        method: 'post',
        data
    });
}
export function deleteArea(data) {
    return fetch({
        url: '/api/services/app/area/DeleteAreaAsync',
        method: 'post',
        data
    });
}