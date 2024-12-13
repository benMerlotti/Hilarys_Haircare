const _apiUrl = "https://localhost:5001"

export const getServices = () => {
    return fetch(`${_apiUrl}/services`).then((r)=> r.json())
}