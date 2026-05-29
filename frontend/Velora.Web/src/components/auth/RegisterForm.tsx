import Logo from "../ui/Logo"
import AuthHeader from "./AuthHeader"
import Input from "./Input"
import AuthButton from "./AuthButton"
import AuthRedirect from "./AuthRedirect"
import { useState } from "react"
import { register } from "../../api/authService"
import Spinner from "../ui/Spinner"





function RegisterForm() {

    const [firstName, setFirstName] = useState('')
const [lastName, setLastName] = useState('')
const [email, setEmail] = useState('')
const [password, setPassword] = useState('')
const [repeatedPassword, setRepeatedPassword] = useState('')
const [errorMessage, setErrorMessage] = useState('')
const [isLoading, setIsLoading] = useState(false)


async function handleRegister() {

    try {
setErrorMessage('')
setIsLoading(true)
        
    await register({
            firstName,
            lastName,
            email,
            password,
            repeatedPassword
        })


    } catch (error) {

        if (error instanceof Error) {
        setErrorMessage(error.message)
        setIsLoading(false)

    }
}
}
    return (
        <div className="w-full max-w-md rounded-3xl bg-blue-950/80 p-8 border-0 md:border border-blue-500 shadow-2xl shadow-violet-900/10 backdrop-blur-md">
            
            <Logo/>

        <AuthHeader
    title="Utwórz swoje konto 👋"
    subtitle="Zacznij zarządzać swoimi finansami"
/>

            <div className="flex flex-col gap-5 mt-8">

            <div className="flex flex-row gap-5 mt-8">
               <Input
                placeholder="Joanna"
                type="text"
                label="Imie"
                value={firstName}
                    onChange={(e) => setFirstName(e.target.value)}/>

                <Input
                placeholder="Kowalska"
                type="text"
                label="Nazwisko"
                value={lastName}
                    onChange={(e) => setLastName(e.target.value)}/>
            
            </div>

            <Input
                placeholder="anna@example.com"
                type="text"
                label="Adres e-mail"
                value={email}
                    onChange={(e) => setEmail(e.target.value)}/>

            <Input
                placeholder="********"
                type="password"
                label="Hasło"
                value={password}
                    onChange={(e) => setPassword(e.target.value)}/>

            <Input
                placeholder="********"
                type="password"
                label="Powtórz hasło"
                value={repeatedPassword}
                    onChange={(e) => setRepeatedPassword(e.target.value)}/>

                                    {
    errorMessage && (
        <p className="text-sm text-red-400">
            {errorMessage}
        </p>
    )
}

{isLoading && (
    <Spinner/>
)}

                <AuthButton onClick={handleRegister}>
                    Zarejestruj się
                </AuthButton>

                        
   

            <AuthRedirect 
            text="Masz już konto?"
            linkText="Zaloguj się"
            to="/login"/>

            </div>

        </div>
    )
}

export default RegisterForm