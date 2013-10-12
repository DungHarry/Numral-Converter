using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter
{
    class Program
    {
        private char[] bChain;
        public char[] oChain;
        public char[] hChain;
        public int dNumber;

        public Program() {
            this.bChain = new char[33];
            this.dNumber = 0;
            this.oChain = new char[12];
            this.hChain = new char[9];
        }

        private char[] stcConvert(string input)
        {
            char[] result = new char[35];
            int iIndex = 10;
            int iStringCount = input.Length - 1;

            for (; iIndex >= 0; iIndex--, iStringCount--)
            {
                if (iStringCount >= 0)
                {
                    result[iIndex] = char.Parse(input.Substring(iStringCount, 1));
                }
                else
                {
                    result[iIndex] = '0';
                }
            }

            result[11] = '\0';

            return result;
        }

        private void enterOctal() 
        {
            string sTemp;

            do
            {
                System.Console.Write("Enter an octal number: ");
                sTemp = System.Console.ReadLine();

                if (sTemp.Length > 11) 
                {
                    System.Console.WriteLine("The length of octal number must less than 11");
                }
            } while (sTemp.Length > 11);

            this.oChain = this.stcConvert(sTemp);
        }

        public int otdConvert()
        {
            this.enterOctal();

            Binary converter = new Binary(this.oChain);

            converter.otbConvert();
            this.dNumber = converter.btdConvert();

            return this.dNumber;
        }

        public char[] othConvert()
        {
            this.enterOctal();

            Binary converter = new Binary(this.oChain);

            converter.otbConvert();
            this.hChain = converter.bthConvert();

            this.hChain[8] = '\0';

            return this.hChain;
        }

        public char[] otbConvert()
        {
            this.enterOctal();

            Binary converter = new Binary(this.oChain);

            this.bChain = converter.otbConvert();

            this.bChain[32] = '\0';

            return this.bChain;
        }

        private void printChars(char[] array) {
            for (int i = 0; array[i] != '\0'; i++)
            {
                System.Console.Write(array[i]);
            }

            System.Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int i;
            
            Program program = new Program();

            System.Console.WriteLine("Author: Dung Harry");
            System.Console.WriteLine("Date created: 12th, October 2013\n\n");

            System.Console.WriteLine("Description: this is the converter program between four numeral system: binary, decimal, heximal, octal\n");

            System.Console.WriteLine("Enter 1 to convert from octal to binary");
            System.Console.WriteLine("Enter 2 to convert from octal to heximal");
            System.Console.WriteLine("Enter 3 to convert from octal to decimal");

            do 
            {
                System.Console.Write("Enter number you choosed: ");
                i = int.Parse(System.Console.ReadLine());

                if ((i < 1) || (i > 4))
                {
                    System.Console.WriteLine("Invalid number\n");
                }
            } while((i < 1) || (i > 4));

            switch (i)
            {
                case 1:
                    {
                        program.otbConvert();

                        System.Console.Write("The binary number: ");
                        program.printChars(program.bChain);
                    } break;

                case 2:
                    {
                        program.othConvert();

                        System.Console.Write("The heximal number: ");
                        program.printChars(program.hChain);
                    } break;

                case 3:
                    {
                        program.otdConvert();

                        System.Console.WriteLine("The decimal number: " + program.dNumber);
                    } break;

                default:
                    break;
            }

            System.Console.ReadKey();
        }
    }

    class Binary
    {
        private char[] bChain;
        public char[] oChain;
        public char[] hChain;
        public int dNumber;

        public Binary()
        {
            this.bChain = new char[33];
            this.dNumber = 0;
            this.oChain = new char[12];
            this.hChain = new char[9];
        }

        public Binary(char[] octalNumber)
        {
            this.bChain = new char[33];
            this.dNumber = 0;
            this.oChain = octalNumber;
            this.hChain = new char[9];
        }

        public char[] dtbConvert() {
            int iNumber = this.dNumber;

            for (int i = 32; i != 0; iNumber >>= 1)
            {
                if ((iNumber % 2) == 0)
                {
                    this.bChain[i - 1] = '0';
                }
                else
                {
                    this.bChain[i - 1] = '1';
                }
            }

            this.bChain[32] = '\0';

            return this.bChain;
        }

        public int btdConvert()
        {
            bool bNeg;
            int iResult = 0;

            if (this.bChain[0] == '1')
            {
                bNeg = true;

                this.rvsBinary();
                this.ictUnitBinary();
            }
            else
            {
                bNeg = false;
            }

            for (int i = 31; i >= 0; i--)
            {
                if (this.bChain[i] == '1')
                {
                    iResult += int.Parse(Math.Pow(2, 31 - i).ToString());
                }
            }

            if (bNeg)
            {
                iResult = -iResult;
            }

            this.dNumber = iResult;

            return iResult;
        }

        public char[] otbConvert()
        {
            int iOctalCount = 10;

            while (iOctalCount >= 0)
            {
                if (iOctalCount == 0)
                {
                    switch (this.oChain[iOctalCount])
                    {
                        case '0':
                            {
                                this.bChain[iOctalCount * 3] = '0';
                                this.bChain[iOctalCount * 3 + 1] = '0';
                            } break;

                        case '1':
                            {
                                this.bChain[iOctalCount * 3] = '0';
                                this.bChain[iOctalCount * 3 + 1] = '1';
                            } break;

                        case '2':
                            {
                                this.bChain[iOctalCount * 3] = '1';
                                this.bChain[iOctalCount * 3 + 1] = '0';
                            } break;

                        case '3':
                            {
                                this.bChain[iOctalCount * 3] = '1';
                                this.bChain[iOctalCount * 3 + 1] = '1';
                            } break;

                        default:
                            break;
                    }
                }
                else
                {
                    switch (this.oChain[iOctalCount])
                    {
                        case '0':
                            {
                                this.bChain[iOctalCount * 3 - 1] = '0';
                                this.bChain[iOctalCount * 3] = '0';
                                this.bChain[iOctalCount * 3 + 1] = '0';
                            } break;

                        case '1':
                            {
                                this.bChain[iOctalCount * 3 - 1] = '0';
                                this.bChain[iOctalCount * 3] = '0';
                                this.bChain[iOctalCount * 3 + 1] = '1';
                            } break;

                        case '2':
                            {
                                this.bChain[iOctalCount * 3 - 1] = '0';
                                this.bChain[iOctalCount * 3] = '1';
                                this.bChain[iOctalCount * 3 + 1] = '0';
                            } break;

                        case '3':
                            {
                                this.bChain[iOctalCount * 3 - 1] = '0';
                                this.bChain[iOctalCount * 3] = '1';
                                this.bChain[iOctalCount * 3 + 1] = '1';
                            } break;

                        case '4':
                            {
                                this.bChain[iOctalCount * 3 - 1] = '1';
                                this.bChain[iOctalCount * 3] = '0';
                                this.bChain[iOctalCount * 3 + 1] = '0';
                            } break;

                        case '5':
                            {
                                this.bChain[iOctalCount * 3 - 1] = '1';
                                this.bChain[iOctalCount * 3] = '0';
                                this.bChain[iOctalCount * 3 + 1] = '1';
                            } break;

                        case '6':
                            {
                                this.bChain[iOctalCount * 3 - 1] = '1';
                                this.bChain[iOctalCount * 3] = '1';
                                this.bChain[iOctalCount * 3 + 1] = '0';
                            } break;

                        case '7':
                            {
                                this.bChain[iOctalCount * 3 - 1] = '1';
                                this.bChain[iOctalCount * 3] = '1';
                                this.bChain[iOctalCount * 3 + 1] = '1';
                            } break;

                        default:
                            break;
                    }
                }

                iOctalCount --;
            }

            this.bChain[32] = '\0';

            return this.bChain;
        }

        public char[] btoConvert()
        {
            int iBinaryCount = 30;

            while (iBinaryCount >= 0)
            {
                if (iBinaryCount == 0)
                {
                    if ((this.bChain[iBinaryCount] == '0') && (this.bChain[iBinaryCount + 1] == '0'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '0';
                    }
                    else if ((this.bChain[iBinaryCount] == '0') && (this.bChain[iBinaryCount + 1] == '1'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '1';
                    }
                    else if ((this.bChain[iBinaryCount] == '1') && (this.bChain[iBinaryCount + 1] == '0'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '2';
                    }
                    else if ((this.bChain[iBinaryCount] == '1') && (this.bChain[iBinaryCount + 1] == '1'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '3';
                    }
                }
                else
                {
                    if ((this.bChain[iBinaryCount - 1] == '0') && (this.bChain[iBinaryCount] == '0') && (this.bChain[iBinaryCount + 1] == '0'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '0';
                    }
                    else if ((this.bChain[iBinaryCount - 1] == '0') && (this.bChain[iBinaryCount] == '0') && (this.bChain[iBinaryCount + 1] == '1'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '1';
                    }
                    else if ((this.bChain[iBinaryCount - 1] == '0') && (this.bChain[iBinaryCount] == '1') && (this.bChain[iBinaryCount + 1] == '0'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '2';
                    }
                    else if ((this.bChain[iBinaryCount - 1] == '0') && (this.bChain[iBinaryCount] == '1') && (this.bChain[iBinaryCount + 1] == '1'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '3';
                    }
                    else if ((this.bChain[iBinaryCount - 1] == '1') && (this.bChain[iBinaryCount] == '0') && (this.bChain[iBinaryCount + 1] == '0'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '4';
                    }
                    else if ((this.bChain[iBinaryCount - 1] == '1') && (this.bChain[iBinaryCount] == '0') && (this.bChain[iBinaryCount + 1] == '1'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '5';
                    }
                    else if ((this.bChain[iBinaryCount - 1] == '1') && (this.bChain[iBinaryCount] == '1') && (this.bChain[iBinaryCount + 1] == '0'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '6';
                    }
                    else if ((this.bChain[iBinaryCount - 1] == '1') && (this.bChain[iBinaryCount] == '1') && (this.bChain[iBinaryCount + 1] == '1'))
                    {
                        this.oChain[int.Parse((iBinaryCount / 3).ToString())] = '7';
                    }
                }

                iBinaryCount -= 3;
            }

            this.oChain[11] = '\0';

            return this.oChain;
        }

        public char[] htbConvert()
        {
            int iHexaCount = 7;

            while (iHexaCount >= 0)
            {
                switch (this.hChain[iHexaCount])
                {
                    case '0':
                        {
                            this.bChain[iHexaCount * 4] = '0';
                            this.bChain[iHexaCount * 4 + 1] = '0';
                            this.bChain[iHexaCount * 4 + 2] = '0';
                            this.bChain[iHexaCount * 4 + 3] = '0';
                        } break;

                    case '1':
                        {
                            this.bChain[iHexaCount * 4] = '0';
                            this.bChain[iHexaCount * 4 + 1] = '0';
                            this.bChain[iHexaCount * 4 + 2] = '0';
                            this.bChain[iHexaCount * 4 + 3] = '1';
                        } break;

                    case '2':
                        {
                            this.bChain[iHexaCount * 4] = '0';
                            this.bChain[iHexaCount * 4 + 1] = '0';
                            this.bChain[iHexaCount * 4 + 2] = '1';
                            this.bChain[iHexaCount * 4 + 3] = '0';
                        } break;

                    case '3':
                        {
                            this.bChain[iHexaCount * 4] = '0';
                            this.bChain[iHexaCount * 4 + 1] = '0';
                            this.bChain[iHexaCount * 4 + 2] = '1';
                            this.bChain[iHexaCount * 4 + 3] = '1';
                        } break;

                    case '4':
                        {
                            this.bChain[iHexaCount * 4] = '0';
                            this.bChain[iHexaCount * 4 + 1] = '1';
                            this.bChain[iHexaCount * 4 + 2] = '0';
                            this.bChain[iHexaCount * 4 + 3] = '0';
                        } break;

                    case '5':
                        {
                            this.bChain[iHexaCount * 4] = '0';
                            this.bChain[iHexaCount * 4 + 1] = '1';
                            this.bChain[iHexaCount * 4 + 2] = '0';
                            this.bChain[iHexaCount * 4 + 3] = '1';
                        } break;

                    case '6':
                        {
                            this.bChain[iHexaCount * 4] = '0';
                            this.bChain[iHexaCount * 4 + 1] = '1';
                            this.bChain[iHexaCount * 4 + 2] = '1';
                            this.bChain[iHexaCount * 4 + 3] = '0';
                        } break;

                    case '7':
                        {
                            this.bChain[iHexaCount * 4] = '0';
                            this.bChain[iHexaCount * 4 + 1] = '1';
                            this.bChain[iHexaCount * 4 + 2] = '1';
                            this.bChain[iHexaCount * 4 + 3] = '1';
                        } break;

                    case '8':
                        {
                            this.bChain[iHexaCount * 4] = '1';
                            this.bChain[iHexaCount * 4 + 1] = '0';
                            this.bChain[iHexaCount * 4 + 2] = '0';
                            this.bChain[iHexaCount * 4 + 3] = '0';
                        } break;

                    case '9':
                        {
                            this.bChain[iHexaCount * 4] = '1';
                            this.bChain[iHexaCount * 4 + 1] = '0';
                            this.bChain[iHexaCount * 4 + 2] = '0';
                            this.bChain[iHexaCount * 4 + 3] = '1';
                        } break;

                    case 'A':
                        {
                            this.bChain[iHexaCount * 4] = '1';
                            this.bChain[iHexaCount * 4 + 1] = '0';
                            this.bChain[iHexaCount * 4 + 2] = '1';
                            this.bChain[iHexaCount * 4 + 3] = '0';
                        } break;

                    case 'B':
                        {
                            this.bChain[iHexaCount * 4] = '1';
                            this.bChain[iHexaCount * 4 + 1] = '0';
                            this.bChain[iHexaCount * 4 + 2] = '1';
                            this.bChain[iHexaCount * 4 + 3] = '1';
                        } break;

                    case 'C':
                        {
                            this.bChain[iHexaCount * 4] = '1';
                            this.bChain[iHexaCount * 4 + 1] = '1';
                            this.bChain[iHexaCount * 4 + 2] = '0';
                            this.bChain[iHexaCount * 4 + 3] = '0';
                        } break;

                    case 'D':
                        {
                            this.bChain[iHexaCount * 4] = '1';
                            this.bChain[iHexaCount * 4 + 1] = '1';
                            this.bChain[iHexaCount * 4 + 2] = '0';
                            this.bChain[iHexaCount * 4 + 3] = '1';
                        } break;

                    case 'E':
                        {
                            this.bChain[iHexaCount * 4] = '1';
                            this.bChain[iHexaCount * 4 + 1] = '1';
                            this.bChain[iHexaCount * 4 + 2] = '1';
                            this.bChain[iHexaCount * 4 + 3] = '0';
                        } break;

                    case 'F':
                        {
                            this.bChain[iHexaCount * 4] = '1';
                            this.bChain[iHexaCount * 4 + 1] = '1';
                            this.bChain[iHexaCount * 4 + 2] = '1';
                            this.bChain[iHexaCount * 4 + 3] = '1';
                        } break;

                    default:
                        break;
                }

                iHexaCount--;
            }

            this.bChain[32] = '\0';

            return this.bChain;
        }

        public char[] bthConvert()
        {
            int iHexaCount = 7;

            while (iHexaCount >= 0)
            {
                if ((this.bChain[iHexaCount * 4] == '0') && (this.bChain[iHexaCount * 4 + 1] == '0') && (this.bChain[iHexaCount * 4 + 2] == '0') && (this.bChain[iHexaCount * 4 + 3] == '0'))
                {
                    this.hChain[iHexaCount] = '0';
                }
                else if ((this.bChain[iHexaCount * 4] == '0') && (this.bChain[iHexaCount * 4 + 1] == '0') && (this.bChain[iHexaCount * 4 + 2] == '0') && (this.bChain[iHexaCount * 4 + 3] == '1'))
                {
                    this.hChain[iHexaCount] = '1';
                }
                else if ((this.bChain[iHexaCount * 4] == '0') && (this.bChain[iHexaCount * 4 + 1] == '0') && (this.bChain[iHexaCount * 4 + 2] == '1') && (this.bChain[iHexaCount * 4 + 3] == '0'))
                {
                    this.hChain[iHexaCount] = '2';
                }
                else if ((this.bChain[iHexaCount * 4] == '0') && (this.bChain[iHexaCount * 4 + 1] == '0') && (this.bChain[iHexaCount * 4 + 2] == '1') && (this.bChain[iHexaCount * 4 + 3] == '1'))
                {
                    this.hChain[iHexaCount] = '3';
                }
                else if ((this.bChain[iHexaCount * 4] == '0') && (this.bChain[iHexaCount * 4 + 1] == '1') && (this.bChain[iHexaCount * 4 + 2] == '0') && (this.bChain[iHexaCount * 4 + 3] == '0'))
                {
                    this.hChain[iHexaCount] = '4';
                }
                else if ((this.bChain[iHexaCount * 4] == '0') && (this.bChain[iHexaCount * 4 + 1] == '1') && (this.bChain[iHexaCount * 4 + 2] == '0') && (this.bChain[iHexaCount * 4 + 3] == '1'))
                {
                    this.hChain[iHexaCount] = '5';
                }
                else if ((this.bChain[iHexaCount * 4] == '0') && (this.bChain[iHexaCount * 4 + 1] == '1') && (this.bChain[iHexaCount * 4 + 2] == '1') && (this.bChain[iHexaCount * 4 + 3] == '0'))
                {
                    this.hChain[iHexaCount] = '6';
                }
                else if ((this.bChain[iHexaCount * 4] == '0') && (this.bChain[iHexaCount * 4 + 1] == '1') && (this.bChain[iHexaCount * 4 + 2] == '1') && (this.bChain[iHexaCount * 4 + 3] == '1'))
                {
                    this.hChain[iHexaCount] = '7';
                }
                else if ((this.bChain[iHexaCount * 4] == '1') && (this.bChain[iHexaCount * 4 + 1] == '0') && (this.bChain[iHexaCount * 4 + 2] == '0') && (this.bChain[iHexaCount * 4 + 3] == '0'))
                {
                    this.hChain[iHexaCount] = '8';
                }
                else if ((this.bChain[iHexaCount * 4] == '1') && (this.bChain[iHexaCount * 4 + 1] == '0') && (this.bChain[iHexaCount * 4 + 2] == '0') && (this.bChain[iHexaCount * 4 + 3] == '1'))
                {
                    this.hChain[iHexaCount] = '9';
                }
                else if ((this.bChain[iHexaCount * 4] == '1') && (this.bChain[iHexaCount * 4 + 1] == '0') && (this.bChain[iHexaCount * 4 + 2] == '1') && (this.bChain[iHexaCount * 4 + 3] == '0'))
                {
                    this.hChain[iHexaCount] = 'A';
                }
                else if ((this.bChain[iHexaCount * 4] == '1') && (this.bChain[iHexaCount * 4 + 1] == '0') && (this.bChain[iHexaCount * 4 + 2] == '1') && (this.bChain[iHexaCount * 4 + 3] == '1'))
                {
                    this.hChain[iHexaCount] = 'B';
                }
                else if ((this.bChain[iHexaCount * 4] == '1') && (this.bChain[iHexaCount * 4 + 1] == '1') && (this.bChain[iHexaCount * 4 + 2] == '0') && (this.bChain[iHexaCount * 4 + 3] == '0'))
                {
                    this.hChain[iHexaCount] = 'C';
                }
                else if ((this.bChain[iHexaCount * 4] == '1') && (this.bChain[iHexaCount * 4 + 1] == '1') && (this.bChain[iHexaCount * 4 + 2] == '0') && (this.bChain[iHexaCount * 4 + 3] == '1'))
                {
                    this.hChain[iHexaCount] = 'D';
                }
                else if ((this.bChain[iHexaCount * 4] == '1') && (this.bChain[iHexaCount * 4 + 1] == '1') && (this.bChain[iHexaCount * 4 + 2] == '1') && (this.bChain[iHexaCount * 4 + 3] == '0'))
                {
                    this.hChain[iHexaCount] = 'E';
                }
                else if ((this.bChain[iHexaCount * 4] == '1') && (this.bChain[iHexaCount * 4 + 1] == '1') && (this.bChain[iHexaCount * 4 + 2] == '1') && (this.bChain[iHexaCount * 4 + 3] == '1'))
                {
                    this.hChain[iHexaCount] = 'F';
                }

                iHexaCount --;
            }

            this.hChain[8] = '\0';

            return this.hChain;
        }

        private void ictUnitBinary()
        {
            int remember = 1, iIndex = 31;

            while ((remember != 0) && (iIndex != -1))
            {
                if (this.bChain[iIndex] == '1')
                {
                    this.bChain[iIndex] = '0';
                }
                else 
                {
                    this.bChain[iIndex] = '1';

                    remember = 0;
                }

                iIndex --;
            }
        }

        private void rvsBinary() 
        {
            int iIndex = 31;

            while (iIndex != -1)
            {
                if (this.bChain[iIndex] == '1')
                {
                    this.bChain[iIndex] = '0';
                }
                else 
                {
                    this.bChain[iIndex] = '1';
                }

                iIndex --;
            }
        }
    }
}
