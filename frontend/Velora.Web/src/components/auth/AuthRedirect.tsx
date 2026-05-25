import { Link } from "react-router-dom"

type AuthRedirectProps = {
    text: string
    linkText: string
    to: string
}

function AuthRedirect({
    text,
    linkText,
    to,
}: AuthRedirectProps) {
    return (
        <div className="text-center mt-2">
            
            <label className="text-gray-400" >{text}</label>

            <Link
                to={to}
                className="
                    ml-2
                    text-violet-500
                    hover:text-violet-400
                    transition
                    cursor-pointer
                "
            >
                {linkText}
            </Link>

        </div>
    )
}

export default AuthRedirect