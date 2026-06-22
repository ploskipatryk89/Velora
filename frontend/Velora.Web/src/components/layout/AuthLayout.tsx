import { Outlet } from "react-router-dom"

function AuthLayout(){
return(
 <div className="min-h-screen flex items-center justify-center bg-blue-950">
        <Outlet/>
    </div>
)
   
    
}

export default AuthLayout