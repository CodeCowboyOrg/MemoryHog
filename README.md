MemoryHog - C# Console Application That Eats Up System Memory
===============================================================================================
This program simulates a memory leak and is initiated via the console.
It takes 3 Parameters at the Console
   1) Parameter 1 - The iterative chunk of memory in megabytes that it will eat up
   2) Parameter 2 - The total memory it will eat up
   3) Parameter 3 - The number of milliseconds it should pause between iterations of eating
Note, to eat up memory it instantiates the XmlNode, this is so that the
COMMITED MEMORY allocated by the OS will be the same as the WORKING SET MEMORY
used by the Process.  Had I used another object which may have been a Primitive Type
other than XmlNode, the WORKING SET MEMORY may show up to actually not be used by the
process and will still be made available for allocation to other Processes.
Thusly, I did what I did because it was quick and dirty and worked for the most part.
You can try to replace XmlNode with say... a Byte[] array and notice that the COMMITED
will not be the same as WORKING SET, and in Task Manager, a good portion of the 
Memory will still show up as Available.
===============================================================================================
