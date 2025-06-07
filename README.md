The ListViewGridViewTest project was developed out of a need to provide a better-performing list view when many hundreds of job records are loaded.  

Previously, a DataGrid was used, but as more complex logic was introduced (for styling and other display features), the DataGrid became slow and unresponsive, even with virtualization turned on.  Though the ListView/GridView 
controls do not have the inherent niceties of the DataGrid, such as auto-sizing columns, it was decided that the performance upgrade outweighed the visual limitations.

This ListView includes several features used in the original DataGrid model, including "traffic light" ellipses meant to indicate various statuses, row-coloring based on job status, text coloring based on the job's offline status,
and converters used to convert the Sales Rep, District, and Customer IDs to display names.

In this project, 3000+ rows are added to the ListView, and there is no noticeable lag or performance degradation, indicating success in achieving the goal of delivering a better-performing list view of jobs. 

