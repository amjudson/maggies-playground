import React from 'react'
import './Pagination.scss'
import FirstPageIcon from '@mui/icons-material/FirstPage'
import LastPageIcon from '@mui/icons-material/LastPage'
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft'
import ChevronRightIcon from '@mui/icons-material/ChevronRight'

interface PaginationProps {
    totalCount: number;
    pageSize: number;
    currentPage: number;
    onPageChange: (page: number) => void;
    onPageSizeChange: (size: number) => void;
}

const pageSizeOptions = [10, 25, 50, 75, 100]

const Pagination: React.FC<PaginationProps> = ({
    totalCount,
    pageSize,
    currentPage,
    onPageChange,
    onPageSizeChange,
}) => {
    const totalPages = Math.max(1, Math.ceil(totalCount / pageSize))
    const startItem = totalCount === 0 ? 0 : (currentPage - 1) * pageSize + 1
    const endItem = Math.min(currentPage * pageSize, totalCount)

    console.log('Pagination props:', { totalCount, pageSize, currentPage, totalPages })

    const getPageNumbers = () => {
        const pages = []
        const maxVisiblePages = 5
        let startPage = Math.max(1, currentPage - Math.floor(maxVisiblePages / 2))
        let endPage = startPage + maxVisiblePages - 1
        if (endPage > totalPages) {
            endPage = totalPages
            startPage = Math.max(1, endPage - maxVisiblePages + 1)
        }
        for (let i = startPage; i <= endPage; i++) {
            pages.push(i)
        }
        return pages
    }

    const handlePageChange = (newPage: number) => {
        console.log('Pagination handlePageChange called with:', newPage)
        console.log('Current page before change:', currentPage)
        onPageChange(newPage)
    }

    const handlePageSizeChange = (newSize: number) => {
        console.log('Pagination handlePageSizeChange called with:', newSize)
        onPageSizeChange(newSize)
    }

    return (
        <div className='pagination'>
            <div className='pagination__main-row'>
                <div className='pagination__info-row'>
                    <span className='pagination__count'>Count: <b>{totalCount}</b></span>
                    <select
                        className='pagination__page-size-select'
                        value={pageSize}
                        onChange={(e) => handlePageSizeChange(Number(e.target.value))}
                        aria-label='Rows per page'
                    >
                        {pageSizeOptions.map((size) => (
                            <option key={size} value={size}>
                                {size}
                            </option>
                        ))}
                    </select>
                    <span className='pagination__per-page-label'>Per Page</span>
                    <span className='pagination__showing'>Showing <b>{startItem}-{endItem}</b></span>
                </div>
                <div className='pagination__navigation'>
                    <button
                        className='pagination__button'
                        onClick={() => handlePageChange(1)}
                        disabled={currentPage === 1}
                        aria-label='First Page'
                        type='button'
                    >
                        <FirstPageIcon />
                    </button>
                    <button
                        className='pagination__button'
                        onClick={() => handlePageChange(currentPage - 1)}
                        disabled={currentPage === 1}
                        aria-label='Previous Page'
                        type='button'
                    >
                        <ChevronLeftIcon />
                    </button>
                    {getPageNumbers().map((page) => (
                        <button
                            key={page}
                            className={`pagination__button${currentPage === page ? ' active' : ''}`}
                            onClick={() => handlePageChange(page)}
                            aria-label={`Page ${page}`}
                            type='button'
                        >
                            {page}
                        </button>
                    ))}
                    <button
                        className='pagination__button'
                        onClick={() => handlePageChange(currentPage + 1)}
                        disabled={currentPage === totalPages}
                        aria-label='Next Page'
                        type='button'
                    >
                        <ChevronRightIcon />
                    </button>
                    <button
                        className='pagination__button'
                        onClick={() => handlePageChange(totalPages)}
                        disabled={currentPage === totalPages}
                        aria-label='Last Page'
                        type='button'
                    >
                        <LastPageIcon />
                    </button>
                </div>
            </div>
        </div>
    )
}

export default Pagination 