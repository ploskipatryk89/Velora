type AuthHeaderProps = {
    title: string
    subtitle: string
}

function AuthHeader({ title, subtitle }: AuthHeaderProps) {
    return (
        <div className="flex flex-col gap-1 text-center">

            <h2 className="text-3xl font-bold text-white ">
                {title}
            </h2>

            <p className="text-gray-500">
                {subtitle}
            </p>

        </div>
    )
}

export default AuthHeader