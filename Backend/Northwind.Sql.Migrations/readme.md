The database of this demonstration sandbox is originated in the Northwind sample provided by Microsoft:
https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs

It is sort-of a great thing that this database comes not only with data, but some _specifies_ which are worth to be altered changed. Also as a conversation opener, the following changes have been added to this local instance of the datastore:

- Customer.Customer id has been renamed to Customer code as this appears to be a human readable string identifier. I find it rather convenient to suffix such identifiers with the term 'code' because it not only implies uniqueness, but also the fact that code generation method/ authority needs to exist in order to create them.


