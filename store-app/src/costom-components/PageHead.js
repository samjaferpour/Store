import React from 'react'
import { Helmet } from 'react-helmet'

const PageHead = (props) => {
    return (
        <div>
            <Helmet>
                <title>{props.title}</title>
            </Helmet>
        </div>
    )
}

export default PageHead