using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Models;
public record SubModel(string Name, string Code, SubSubModel SubSubModel12);

public record SubSubModel(string Dupa);