type InputProps = {
    label: string
    placeholder: string
    type?: string
    value: string
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void
}

function Input({
    label,
    type,
    placeholder,
    value,
    onChange
}: InputProps) {
    return (
        <div className="flex flex-col gap-2">

            <label className="text-sm text-gray-300">
                {label}
            </label>

            <input
                type={type}
                placeholder={placeholder}
                value={value}
                onChange={onChange}
                className="
                    w-full
                    rounded-xl
                    bg-blue-950
                    border
                    border-blue-900
                    px-4
                    py-3
                    text-white
                    outline-none
                    transition
                    focus:border-violet-500
                    focus:ring-2
                    focus:ring-violet-500/20
                "
            />

        </div>
    )
}

export default Input