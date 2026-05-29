
import { API_BASE_URL } from "./config";

export async function get<TResponse>(endpoint:string) : Promise<TResponse> {
    
    const response = await fetch(`${API_BASE_URL}${endpoint}`);

    if (!response.ok){
        const errorData = await response.json();

        throw new Error(errorData.title);
    }

    return response.json();
}

export async function post<TRequest, TResponse>(endpoint: string, data: TRequest): Promise<TResponse> {
    const response = await fetch(`${API_BASE_URL}${endpoint}`, {
        method: 'POST',
        //naglowek, wysylam json
        headers: {
            
            'Content-Type': 'application/json'
        },
        //zawartosc requestru
        //http nie wysyla obiektow js, wiec JSON.stringify, zamienia data na json
        body: JSON.stringify(data)
    });

    //sprawdza czy request sie udal
   if (!response.ok) {

    const errorData = await response.json();

    if (errorData.errors) {

        const validationErrors = Object.values(errorData.errors)
            .flat()
            .join("\n");

        throw new Error(validationErrors);
    }

    throw new Error(
        errorData.title ||
        errorData.message ||
        "Wystąpił błąd"
    );
}
//zwraca dane
    return response.json();
}