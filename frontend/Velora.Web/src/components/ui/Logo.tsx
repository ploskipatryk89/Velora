import logo from '../../assets/images/velora-logo.png'

function Logo() {
    return (
        <div className="flex items-center justify-center gap-3 mb-6">
            <img
                src={logo}
                alt="Velora Logo"
                className="h-10 w-auto object-contain"
            />

            <h1 className="text-3xl font-bold text-white " >
                Velora
            </h1>
        </div>
    )
}

export default Logo