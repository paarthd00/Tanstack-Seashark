import { Outlet, Link, createRootRoute } from '@tanstack/react-router'
export const Route = createRootRoute({
    component: () => (
        <>
            <div className="p-2 flex gap-2">
                <Link to="/" className="[&.active]:font-bold">
                    List
                </Link>{' '}
                <Link to="/addgun" className="[&.active]:font-bold">
                    Add Gun
                </Link>
            </div>
            <hr />
            <Outlet />
        </>
    ),
})