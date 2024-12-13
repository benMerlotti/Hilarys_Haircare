const _apiUrl = "https://localhost:5001"

export const getStylists = () => {
    return fetch(`${_apiUrl}/stylists`).then((r)=> r.json())
}

export const toggleStylistStatus = (id) => {
    return fetch(`${_apiUrl}/stylists/toggle-status/${id}`, {
        method: "PUT",
        headers: { "Content-Type" : "application/json" }
    }).then((r)=> r.json())
}
    