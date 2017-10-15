function myDataTables(handler)
{
    $(handler).DataTable({
        "language": {
            "lengthMenu": "Wyświetlaj _MENU_ wyników na stronę",
            "zeroRecords": "Nic nie znaleziono ",
            "info": "Pokaż _PAGE_ z _PAGES_",
            "infoEmpty": "No records available",
            "infoFiltered": "(filtered from _MAX_ total records)",
            "search": "Wyszukiwanie",
            "paginate": {
                "first": "Pierwsza",
                "last": "Ostatnia",
                "next": "Następna",
                "previous": "Poprzednia"
            },
        }
    });

}