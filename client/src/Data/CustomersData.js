const _apiUrl = "https://localhost:5001"

export const getCustomers = () => {
    return fetch(`${_apiUrl}/customers`).then((r)=> r.json())
}