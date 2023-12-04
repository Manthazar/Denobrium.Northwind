The database of this demonstration sandbox is originated in the Northwind sample provided by Microsoft:
https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs

It is sort-of a great thing that this database comes not only with data, but some _specifies_ which are worth to be altered changed. Also as a conversation opener, the following changes have been added to this local instance of the datastore:

Identifier changes:
_A single id type enables a single generic access mechanism allows for less thinking. Alternative ids, such as human readable codes can remain, but the 'Code' suffix convention. The primary code is just called 'Code' _
More rationale is provided into the migration themselves.

Schema changes:
- There is some mess around 'CustomerDemographic' and accompaning link table where standard conventions are not followed. Moreover, 'CustomerDemographic' seems actually to be a simple type table.
- Abbreviations are avoided, i.e. TypeDesc --> Description



