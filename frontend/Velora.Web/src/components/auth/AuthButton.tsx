type ButtonProps = {
    children: React.ReactNode
    onClick?: () => void
}

function AuthButton({ children, onClick}: ButtonProps) {
    return (
        <button
        onClick={onClick}
            className="
                mt-2
                rounded-2xl
                bg-violet-600
                py-3
                font-semibold
                text-white
                transition
                hover:bg-violet-500
                cursor-pointer
            "
        >
            {children}
        </button>
    )
}

export default AuthButton