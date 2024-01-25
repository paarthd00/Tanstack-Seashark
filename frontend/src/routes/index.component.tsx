import {
    useQuery,
} from '@tanstack/react-query'

import { getGuns } from '../api'

export const component = function Home() {
  const {
    isPending,
    error,
    data: guns,
  } = useQuery({
    gcTime: Infinity,
    queryKey: ["get-all-guns"],
    queryFn: getGuns,
  });    
    console.log(guns);
    return (
        <div className="container">
            This is the gun page
        </div>
    )
}
